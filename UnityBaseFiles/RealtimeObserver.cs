using System;
using System.Collections;
using System.Collections.Generic;
using DynamicPixels.GameService.Models;
using DynamicPixels.GameService.Services.MultiPlayer.Room;
using DynamicPixels.GameService.Services.User.Models;
using Newtonsoft.Json;
using UnityEngine;

namespace DynamicPixels.Services.MultiPlayer.Realtime
{
    public class RealtimeObserver : MonoBehaviour
    {
        [SerializeField] private RealtimeSetting settings;
        private Dictionary<string, DynamicObject> _trackedObjects;
        private Dictionary<Tuple<string, string>, DynamicVariableBase> _trackedVariables;
        private List<Action> _mainThreadActions;
        
        private User _user;
        
        private static RealtimeObserver _instance;

        private Dictionary<Room, Coroutine> _roomCoroutines;
        
        public static RealtimeObserver Instance => _instance;

        private void Awake()
        {
            _trackedObjects = new Dictionary<string, DynamicObject>();
            _trackedVariables = new Dictionary<Tuple<string, string>, DynamicVariableBase>();
            _roomCoroutines = new Dictionary<Room, Coroutine>();
            _mainThreadActions = new List<Action>();
            _instance = this;
        }

        public void StartSync(Room room, User user, bool isSender)
        {
            _user = user;
            room.OnMessageReceived += MessageReceived;
            if (isSender)
                _roomCoroutines.Add(room, StartCoroutine(StartSyncing(room)));
        }

        public void StopSync(Room room)
        {
            StopCoroutine(_roomCoroutines[room]);
            _roomCoroutines.Remove(room);
        }

        private void Update()
        {
            if (_mainThreadActions.Count > 0)
            {
                foreach (var action in _mainThreadActions)
                {
                    action();
                }
                _mainThreadActions.Clear();
            }
        }

        private void MessageReceived(object sender, Request e)
        {
            if (e.SenderId == _user.Id)
                return;
            var intermediatePayload = JsonConvert.DeserializeObject<string>(e.Payload);
            var data = JsonConvert.DeserializeObject<RealtimeObservationModel>(intermediatePayload);
            foreach (var part in data.messageParts)
            {
                switch (part.type)
                {
                    case "Position":
                        _mainThreadActions.Add(() => _trackedObjects[part.guid].transform.position = part.vector);
                        break;
                    case "Rotation":
                        _mainThreadActions.Add(() => _trackedObjects[part.guid].transform.rotation = Quaternion.Euler(part.vector));
                        break;
                    case "Scale":
                        _mainThreadActions.Add(() => _trackedObjects[part.guid].transform.localScale = part.vector);
                        break;
                    default:
                        break;
                }
            }
            foreach (var part in data.variables)
                _mainThreadActions.Add(() => _trackedVariables[new Tuple<string, string>(part.guid, part.fieldName)].SetValueByDeserializedString(part.data));
        }  

        private IEnumerator StartSyncing(Room room)
        {
            while (true)
            {
                var temp = new RealtimeObservationModel();
                foreach (var obj in _trackedObjects.Keys)
                {
                    temp.messageParts.AddRange(_trackedObjects[obj].GetMessageParts());
                }
                foreach (var obj in _trackedVariables.Keys)
                {
                    temp.variables.Add(_trackedVariables[obj].GetVariablePart());
                }
                room.Broadcast(JsonConvert.SerializeObject(temp));
                yield return new WaitForSecondsRealtime(1f / settings.dataTransferRate);
            }
        }
        

        public void TrackObject(DynamicObject dynamicObject)
        {
            _trackedObjects.Add(dynamicObject.GetGuid(), dynamicObject);
        }

        public void ObserveVariable(string guid, string fieldName, DynamicVariableBase variable)
        {
            _trackedVariables.Add(new Tuple<string, string>(guid, fieldName), variable);
        }
    }
}
