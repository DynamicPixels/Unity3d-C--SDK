using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UnityEngine;
using WebSocketSharp;

namespace DynamicPixels.Services.MultiPlayer.Realtime
{

    public class DynamicWrapper : MonoBehaviour
    {
        [HideInInspector] [SerializeField] protected string guid; 
        
        private void OnValidate()
        {
            if (guid.IsNullOrEmpty())
            {
                guid = Guid.NewGuid().ToString();
            }
        }

        public void ResetGuid()
        {
            guid = "";
            SetGuid();
        }
        public void Start()
        {
            if (guid.IsNullOrEmpty())
                guid = Guid.NewGuid().ToString();
            RealtimeObserver.Instance.AddDynamicWrapper(this);
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(DynamicVariableBase)))
                {
                    DynamicVariableBase value = (DynamicVariableBase)field.GetValue(this);
                    value.Initialize(RealtimeObserver.Instance, field.Name);
                }
            }
            
        }

        public void OnDestroy()
        {
            RealtimeObserver.Instance.RemoveDynamicWrapper(this);
            FieldInfo[] fields = GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var field in fields)
            {
                if (field.FieldType.IsSubclassOf(typeof(DynamicVariableBase)))
                {
                    DynamicVariableBase value = (DynamicVariableBase)field.GetValue(this);
                    value.StopTracking();
                }
            }
        }

        public string GetGuid()
        {
            return guid;
        }

        public void SetGuid(string guidToSet = "")
        {
            guid = guidToSet.IsNullOrEmpty() ? Guid.NewGuid().ToString() : guidToSet;
        }
    }

    public class DynamicVariableBase
    {
        protected RealtimeObserver Observer;
        
        protected string FieldName;

        public virtual void Initialize(RealtimeObserver observer, string fieldName) {}

        public virtual void SetValueByDeserializedString(string value){}
        public virtual void StartTracking(){}

        public virtual SyncingVariable GetVariablePart()
        {
            return null;
        }

        public virtual void StopTracking(){}
    }
    
    [Serializable]
    public class DynamicVariable<T> : DynamicVariableBase
    {
        private T _value;
        private DynamicWrapper _parentGameObject;
        
        public Action<T, T> OnValueChanged;
        public DynamicVariable(DynamicWrapper parentGameObject)
        {
            _parentGameObject = parentGameObject;
        }

        public override void Initialize(RealtimeObserver observer, string fieldName)
        {
            Observer = observer;
            FieldName = fieldName;
        }

        public override void SetValueByDeserializedString(string value)
        {
            var temp = _value;
            _value = JsonConvert.DeserializeObject<T>(value);
            OnValueChanged?.Invoke(temp, _value);
        }

        public override void StartTracking()
        {
            Observer.TrackVariable(_parentGameObject.GetGuid(), FieldName, this);
        }

        public override void StopTracking()
        {
            Observer.UnTrackVariable(_parentGameObject.GetGuid(), FieldName, this);
        }

        public void ChangeValue(T value)
        {
            _value = value;
        }

        public T GetValue()
        {
            return _value;
        }

        public override SyncingVariable GetVariablePart()
        {
            return new SyncingVariable{data = JsonConvert.SerializeObject(_value), fieldName = FieldName, guid = _parentGameObject.GetGuid()};
        }
    }
}