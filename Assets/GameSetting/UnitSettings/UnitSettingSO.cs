using UnityEngine;
using System;

using TestProject.DevOOP.Units.Modules;

namespace TestProject.DevOOP.Settings
{
    [CreateAssetMenu(fileName ="NewUnitSeting", menuName = "Game/Setting/Unit")]
    public sealed class UnitSettingSO : ScriptableObject
    {
        public UnitType UnitType { get => _unitType; }
        [SerializeField] private UnitType _unitType = UnitType.None;
        public GameObject UnitVisual { get => _unitVisual; }
        [SerializeField] private GameObject _unitVisual;
        [SerializeField] private ModuleType[] _useUnitModulesType;
        //AI test
        [SerializeField] private AISettingSO _unitAISetting;

        public ModuleType GetModuleType(int index)
        {
            ModuleType currentType = ModuleType.None;
            try
            {
                if(index > _useUnitModulesType.Length)
                {
                    _Debug.Log($"Exeption! Инекс запроса <b>({index})</b> моудля больше <b>({_useUnitModulesType.Length})</b> чем храниться в текущем файле настройки - <b>{this.name}</b>!", DebugColor.red);
                    throw new Exception();
                }
                currentType = _useUnitModulesType[index];
            }
            catch(Exception e)
            {
                GameUtility.ExceptionHandler(e);
            }
            return currentType;
        }

        public int GetUnitModulesLenght()
        {
            return _useUnitModulesType.Length;
        }
    }
}

