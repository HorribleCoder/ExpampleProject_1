using UnityEngine;

namespace TestProject.DevOOP.Settings
{
    [CreateAssetMenu(fileName = "NewAISetting", menuName = "Game/Setting/AI")]
    public sealed class AISettingSO : ScriptableObject
    {
        [Range(0f, 10f)]
        public float searchDistance;
        [Range(1,10)]
        public int unitDamage;
        [Range(1,100)]
        public int unitHealth;
    }
}