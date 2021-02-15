using UnityEngine;

using TestProject.DevOOP.Settings;

namespace TestProject.DevOOP.Units
{
    /// <summary>
    /// Main Class all unit in game.
    /// </summary>
    /// <remarks>
    /// Subdivided on partial class:
    /// <list type="number">
    /// <item>
    /// <description>BaseGameUnit_Module - create all module path <see cref="CreateUnitModules"/>.</description>
    /// </item>
    /// <item>
    /// <description>BaseGameUnit_Event - create all unit-event for work path <see cref="CreateUnitEvent"/>.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public abstract partial class BaseGameUnit : MonoBehaviour
    {
        public Transform SelfTransform { get => _selfTransform; }
        private Transform _selfTransform;
        [SerializeField] private UnitSettingSO _unitSetting;

        //TODO Сделать остальные раширения класса BaseGameUnit - AI
        #region Partial Function
        partial void CreateUnitEvent();
        partial void CreateUnitModules();
        partial void CreateUnitAI();

        #endregion

        private void Awake()
        {
            _selfTransform = this.transform;
            CreateUnitEvent();
            CreateUnitModules();
            CreateUnitAI();
        }
    }
}

