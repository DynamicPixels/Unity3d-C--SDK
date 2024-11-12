using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using WebSocketSharp;

namespace DynamicPixels.Services.MultiPlayer.Realtime
{
    public class DynamicObject : DynamicWrapper
    {
        [SerializeField] private bool syncPosition;
        [SerializeField] private bool syncRotation;
        [SerializeField] private bool syncScale;

        private new void Start()
        {
            base.Start();
            RealtimeObserver.Instance.TrackObject(this);
        }
        
        private new void OnDestroy()
        {
            base.OnDestroy();
            RealtimeObserver.Instance.UnTrackObject(this);
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
    }
}
