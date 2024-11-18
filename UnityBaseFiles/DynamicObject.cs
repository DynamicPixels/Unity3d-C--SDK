using System;
using System.Collections.Generic;
using DynamicPixelsInitializer;
using UnityEngine;
using UnityEngine.Serialization;
using WebSocketSharp;

namespace DynamicPixels.Services.MultiPlayer.Realtime
{
    /// <summary>
    /// Represents a dynamic object in the multiplayer environment that can synchronize its position, rotation, and scale.
    /// </summary>
    public class DynamicObject : DynamicWrapper
    {
        /// <summary>
        /// Indicates whether the object's position should be synchronized.
        /// </summary>
        [SerializeField] private bool syncPosition;

        /// <summary>
        /// Indicates whether the object's rotation should be synchronized.
        /// </summary>
        [SerializeField] private bool syncRotation;

        /// <summary>
        /// Indicates whether the object's scale should be synchronized.
        /// </summary>
        [SerializeField] private bool syncScale;
        private new void Start()
        {
            base.Start();
            RealtimeObserversManager.Instance.GetObserver(observerId).TrackObject(this);
        }
        private new void OnDestroy()
        {
            base.OnDestroy();
            RealtimeObserversManager.Instance.GetObserver(observerId).UnTrackObject(this);
        }

        /// <summary>
        /// Collects the synchronization data for the object's position, rotation, and scale.
        /// </summary>
        /// <returns>A list of synchronization message parts describing the object's state.</returns>
        public List<SyncingMessagePart> GetMessageParts()
        {
            var result = new List<SyncingMessagePart>();
            if (syncPosition)
                result.Add(new SyncingMessagePart() { guid = guid, vector = transform.position, type = "Position" });
            if (syncRotation)
                result.Add(new SyncingMessagePart() { guid = guid, vector = transform.rotation.eulerAngles, type = "Rotation" });
            if (syncScale)
                result.Add(new SyncingMessagePart() { guid = guid, vector = transform.localScale, type = "Scale" });
            return result;
        }
    }
}
