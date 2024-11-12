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
        private Dictionary<string, DynamicWrapper> _dynamicWrappers;
        private Dictionary<string, DynamicObject> _trackedObjects;
        private Dictionary<Tuple<string, string>, DynamicVariableBase> _trackedVariables;
        private List<InstantiationModel> _objectsToInstantiate;
        private List<string> _objectsToDestroy;
        private List<Action> _mainThreadActions;
        
        private User _user;
        
        private static RealtimeObserver _instance;

        private Dictionary<Room, Coroutine> _roomCoroutines;
        
        public static RealtimeObserver Instance => _instance;

        private void Awake()
        {
            _trackedObjects = new Dictionary<string, DynamicObject>();
            _objectsToDestroy = new List<string>();
            _objectsToInstantiate = new List<InstantiationModel>();
            _trackedVariables = new Dictionary<Tuple<string, string>, DynamicVariableBase>();
            _dynamicWrappers = new Dictionary<string, DynamicWrapper>();
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
            foreach (var instantiationModel in data.instantiations)
            {
                if (instantiationModel.inScene)
                {
                    _mainThreadActions.Add(() =>
                    {
                        var temp = Instantiate(_dynamicWrappers[instantiationModel.objectName], instantiationModel.position,
                            Quaternion.Euler(instantiationModel.rotation));
                        temp.SetGuid(instantiationModel.guid);
                    });
                }
                else
                {
                    _mainThreadActions.Add(() =>
                    {
                        var temp = Instantiate(Resources.Load<DynamicWrapper>(instantiationModel.objectName),
                            instantiationModel.position, Quaternion.Euler(instantiationModel.rotation));
                        temp.SetGuid(instantiationModel.guid);
                        
                    });
                }
            }
                
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
            foreach (var part in data.destroys)
                _mainThreadActions.Add(() => Destroy(_dynamicWrappers[part].gameObject));
        }  

        private IEnumerator StartSyncing(Room room)
        {
            while (true)
            {
                var temp = new RealtimeObservationModel();
                temp.instantiations.AddRange(_objectsToInstantiate);
                _objectsToInstantiate.Clear();
                temp.destroys.AddRange(_objectsToDestroy);
                _objectsToDestroy.Clear();
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
        public void UnTrackObject(DynamicObject dynamicObject)
        {
            _trackedObjects.Remove(dynamicObject.GetGuid());
        }
        
        public void AddDynamicWrapper(DynamicWrapper dynamicObject)
        {
            _dynamicWrappers.Add(dynamicObject.GetGuid(), dynamicObject);
        }
        public void RemoveDynamicWrapper(DynamicWrapper dynamicObject)
        {
            _dynamicWrappers.Remove(dynamicObject.GetGuid());
        }

        public void TrackVariable(string guid, string fieldName, DynamicVariableBase variable)
        {
            _trackedVariables.Add(new Tuple<string, string>(guid, fieldName), variable);
        }
        public void UnTrackVariable(string guid, string fieldName, DynamicVariableBase variable)
        {
            _trackedVariables.Remove(new Tuple<string, string>(guid, fieldName));
        }

        public DynamicWrapper InstantiateFromScene(DynamicWrapper objectToInstantiate, Vector3 position, Quaternion rotation)
        {
            var tempObject = Instantiate(objectToInstantiate, position, rotation);
            tempObject.ResetGuid();
            var dataobject = new InstantiationModel()
            {
                inScene = true,
                objectName = objectToInstantiate.GetGuid(),
                guid = tempObject.GetGuid(),
                position = position,
                rotation = rotation.eulerAngles
            };
            _objectsToInstantiate.Add(dataobject);
            return tempObject;
        }
        
        public DynamicWrapper InstantiateFromResources(string objectToInstantiate, Vector3 position, Quaternion rotation)
        {
            DynamicWrapper wrapperToInstantiate = Resources.Load<DynamicWrapper>(objectToInstantiate);
            if (!wrapperToInstantiate)
            {
                Debug.Log("[DynamicPixels] Object not found to instantiate");
                return null;
            }
            var tempObject = Instantiate(wrapperToInstantiate, position, rotation);
            tempObject.ResetGuid();
            var dataobject = new InstantiationModel()
            {
                inScene = false,
                objectName = objectToInstantiate,
                guid = tempObject.GetGuid(),
                position = position,
                rotation = rotation.eulerAngles
            };
            _objectsToInstantiate.Add(dataobject);
            return tempObject;
        }

        public void DestroyDynamicWrapper(string guid)
        {
            if (_dynamicWrappers.ContainsKey(guid))
            {
                Destroy(_dynamicWrappers[guid].gameObject);
                _objectsToDestroy.Add(guid);
            }
        }
    }
}
