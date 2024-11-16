using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DynamicPixels
{
    [CreateAssetMenu(fileName = "RealtimeSetting", menuName = "DynamicPixels/RealtimeSetting")]
    public class RealtimeSetting : ScriptableObject
    {
        public int dataTransferRate;
    }
}
