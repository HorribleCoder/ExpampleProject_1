using System;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class IdleState : BaseState
    {
        public override void EnterState()
        {
            StateDebug("Enter");
            var arg = GameUtility.GetEventArgByType<UnitMovementEventArgs>();
            arg.MoveSpeed = GameConst.IdleUnitSpeed;
            arg.MovePoint = Vector3.zero;
            owner.ExecutUnitEvent(arg);
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();
            //TODO check something trans-events
            //capture - transition
            if()
            //move - transition
            if(owner.GetDistanceTo() > 0.5f)
            {
                resultStateType = typeof(MoveState);
            }

            return resultStateType;
        }

        public override void ExiteState()
        {
            StateDebug("Exit");
        }
    }
}