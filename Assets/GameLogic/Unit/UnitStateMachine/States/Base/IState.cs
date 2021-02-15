using System;

namespace TestProject.DevOOP.Units.USM
{
    internal interface IState<T>
    {
        void SetUnitOwner(T owner);
        void EnterState();
        Type ExecuteState();
        void ExiteState();
    }
}