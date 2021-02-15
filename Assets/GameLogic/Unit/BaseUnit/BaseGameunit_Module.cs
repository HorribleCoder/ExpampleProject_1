using System;
using System.Collections.Generic;
using UnityEngine;

using TestProject.DevOOP.Units.Modules;


namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit
    {
        // текущий список всех модулей Юнита
        private List<IUnitModule> _unitModuleList;

        partial void CreateUnitModules()
        {
            try
            {
                if(_unitSetting is null)
                {
                    _Debug.Log($"Exeption! У юнита нет файла настройки - <b>{gameObject.name}</b>!", DebugColor.red);
                    throw new Exception();
                }
                _unitModuleList = new List<IUnitModule>();
                GameObject currentOwner = default;
                Factory.ModuleGameFactory moduleFactory = Mediator.Instance.GetInstanceByType<Factory.ModuleGameFactory>();
                for (int i = 0; i < _unitSetting.GetUnitModulesLenght(); ++i)
                {
                    currentOwner = this.gameObject;
                    if (_unitSetting.GetModuleType(i) == ModuleType.Visual)
                    {
                        currentOwner = Instantiate(_unitSetting.UnitVisual);
                        currentOwner.transform.SetParent(this.transform);
                        currentOwner.transform.localPosition = Vector3.zero;
                    }
                    _unitModuleList.Add(moduleFactory.Create(_unitSetting.GetModuleType(i)));
                    _unitModuleList[i].AddModule(AddUnitEvent, currentOwner);
                }
            }
            catch(Exception e)
            {
                GameUtility.ExceptionHandler(e);
            }
        }
    }
}