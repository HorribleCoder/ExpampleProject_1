using System.Collections;
using UnityEngine;

namespace TestProject.DevOOP
{
    public sealed class CaptureNavPoint : GameNavPoint
    {
        public float CaptureRadius { get => _captureRadius; }
        [Range(0f,10f)]
        [SerializeField] private float _captureRadius;
    }
}