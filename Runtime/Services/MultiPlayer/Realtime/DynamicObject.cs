using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WebSocketSharp;

namespace DynamicPixels
{
    public class DynamicObject : MonoBehaviour
    {
        [FormerlySerializedAs("_guid")] [HideInInspector][SerializeField] private string guid;
        [SerializeField] private bool syncPosition;
        [SerializeField] private bool syncRotation;
        [SerializeField] private bool syncScale;

        private void OnValidate()
        {
            if (guid.IsNullOrEmpty())
            {
                guid = Guid.NewGuid().ToString();
            }
            Debug.Log(guid);
        }

        private void Start()
        {
            RealtimeObserver.Instance.TrackObject(this);
        }

        public List<SyncingMessagePart> GetMessageParts()
        {
            var result = new List<SyncingMessagePart>();
            if (syncPosition)
                result.Add(new SyncingMessagePart(){guid = guid, vector = transform.position, type = "Position"});
            if (syncRotation)
                result.Add(new SyncingMessagePart(){guid = guid, vector = transform.rotation.eulerAngles, type = "Rotation"});
            if (syncScale)
                result.Add(new SyncingMessagePart(){guid = guid, vector = transform.localScale, type = "Scale"});
            return result;
        }

        public string GetGuid()
        {
            return guid;
        }
    }
}
