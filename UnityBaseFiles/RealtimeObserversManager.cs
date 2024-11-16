using System.Collections;
using System.Collections.Generic;
using DynamicPixels.Services.MultiPlayer.Realtime;
using UnityEngine;

namespace DynamicPixelsInitializer
{
    public class RealtimeObserversManager : MonoBehaviour
    {
        private static RealtimeObserversManager _instance;
        private Dictionary<int, RealtimeObserver> _observers;
        public static RealtimeObserversManager Instance => _instance;
        private void Awake()
        {
            _instance = this;
            _observers = new Dictionary<int, RealtimeObserver>();
        }

        public void AddObserver(RealtimeObserver observer, int id)
        {
            _observers.Add(id, observer);
        }
        public void RemoveObserver(int id)
        {
            _observers.Remove(id);
        }

        public RealtimeObserver GetObserver(int id)
        {
            return _observers[id];
        }
    }
}
