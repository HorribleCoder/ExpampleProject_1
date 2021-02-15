using System;
using UnityEngine;

namespace TestProject.DevOOP
{
    public interface IUnitModule
    {
        void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner);
        void RemoveModule(Action<Type, EventHandler> removeEventHandler);
    }
}