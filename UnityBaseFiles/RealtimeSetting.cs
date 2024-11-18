using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicPixels
{
    /// <summary>
    /// Represents the configuration settings for realtime data synchronization in the DynamicPixels framework.
    /// </summary>
    [CreateAssetMenu(fileName = "RealtimeSetting", menuName = "DynamicPixels/RealtimeSetting")]
    public class RealtimeSetting : ScriptableObject
    {
        /// <summary>
        /// The rate at which data is transferred during synchronization, measured in updates per second.
        /// </summary>
        public int dataTransferRate;
    }
}