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
        public void Start()
        {

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
        
        public string GetGuid()
        {
            return guid;
        }
    }

    public class DynamicVariableBase
    {
        protected RealtimeObserver Observer;
        
        protected string FieldName;

        public virtual void Initialize(RealtimeObserver observer, string fieldName) {}

        public virtual void SetValueByDeserializedString(string value){}

        public virtual SyncingVariable GetVariablePart()
        {
            return null;
        }
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
            Observer.ObserveVariable(_parentGameObject.GetGuid(), fieldName, this);
        }

        public override void SetValueByDeserializedString(string value)
        {
            var temp = _value;
            _value = JsonConvert.DeserializeObject<T>(value);
            OnValueChanged?.Invoke(temp, _value);
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