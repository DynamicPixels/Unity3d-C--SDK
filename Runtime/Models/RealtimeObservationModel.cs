using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicPixels
{
    [Serializable]
    public class SyncingMessagePart
    {
        public string guid;
        public string type;
        public Vector3 vector;
    }
    [Serializable]
    public class RealtimeObservationModel
    {
        public List<SyncingMessagePart> messageParts = new List<SyncingMessagePart>();
    }
}
