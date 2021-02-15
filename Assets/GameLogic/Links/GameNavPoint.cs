using UnityEngine;

namespace TestProject.DevOOP
{
    public class GameNavPoint : BaseGameLink
    {
        public Vector3 Position { get => this.transform.position; }
        public PointType PointType { get => _pointType; }
        [SerializeField] private PointType _pointType = PointType.None;
    }
}