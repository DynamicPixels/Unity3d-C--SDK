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
    public class SyncingVariable
    {
        public string guid;
        public string fieldName;
        public string data;
    }
    [Serializable]
    public class RealtimeObservationModel
    {
        public List<SyncingMessagePart> messageParts = new List<SyncingMessagePart>();
        public List<SyncingVariable> variables = new List<SyncingVariable>();
    }
}
