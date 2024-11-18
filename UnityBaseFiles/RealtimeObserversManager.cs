using System.Collections;
using System.Collections.Generic;
using DynamicPixels.Services.MultiPlayer.Realtime;
using UnityEngine;

namespace DynamicPixelsInitializer
{
    /// <summary>
    /// Manages all <see cref="RealtimeObserver"/> instances in the multiplayer environment.
    /// Provides functionality to add, remove, and retrieve observers by their unique IDs.
    /// </summary>
    public class RealtimeObserversManager : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance of the <see cref="RealtimeObserversManager"/>.
        /// </summary>
        private static RealtimeObserversManager _instance;

        /// <summary>
        /// Dictionary storing observers by their unique IDs.
        /// </summary>
        private Dictionary<int, RealtimeObserver> _observers;

        /// <summary>
        /// Gets the singleton instance of the <see cref="RealtimeObserversManager"/>.
        /// </summary>
        public static RealtimeObserversManager Instance => _instance;

        /// <summary>
        /// Initializes the singleton instance and prepares the observer dictionary.
        /// </summary>
        private void Awake()
        {
            _instance = this;
            _observers = new Dictionary<int, RealtimeObserver>();
        }

        /// <summary>
        /// Adds a new observer to the manager.
        /// </summary>
        /// <param name="observer">The observer to add.</param>
        /// <param name="id">The unique ID associated with the observer.</param>
        public void AddObserver(RealtimeObserver observer, int id)
        {
            _observers.Add(id, observer);
        }

        /// <summary>
        /// Removes an observer from the manager by its ID.
        /// </summary>
        /// <param name="id">The unique ID of the observer to remove.</param>
        public void RemoveObserver(int id)
        {
            _observers.Remove(id);
        }

        /// <summary>
        /// Retrieves an observer by its ID.
        /// </summary>
        /// <param name="id">The unique ID of the observer to retrieve.</param>
        /// <returns>The <see cref="RealtimeObserver"/> associated with the specified ID.</returns>
        public RealtimeObserver GetObserver(int id)
        {
            return _observers[id];
        }
    }
}
