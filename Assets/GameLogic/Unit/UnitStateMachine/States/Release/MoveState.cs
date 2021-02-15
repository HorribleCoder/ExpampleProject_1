using System;
using System.Collections;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class MoveState : BaseState
    {
        public override void EnterState()
        {
            StateDebug("Enter");
            //var arg = Mediator.Instance.GetInstanceByType<GamePool.UnitEventArgsPool>().Get(typeof(UnitMovementEventArgs)) as UnitMovementEventArgs;
            var arg = GameUtility.GetEventArgByType<UnitMovementEventArgs>();
            arg.MoveSpeed = GameConst.MoveUnitSpeed;
            arg.MovePoint = owner.GetMovePoint();
            owner.ExecutUnitEvent(arg);
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();
            //TODO check something trans-events
            //hunt - transition
            if (owner.CheckCloserEnemy())
            {
                resultStateType = typeof(HuntState);
            }
            else
            {
                //idle - transition
                //TODO вынос 0,25 в конфиг - дистанция остановки
                if (owner.GetDistanceTo() <= 2f)//see setup nav agent
                {
                    resultStateType = typeof(IdleState);
                    owner.MovementComplite();
                }
            }

            return resultStateType;
        }

        public override void ExiteState()
        {
            StateDebug("Exit");
        }
    }
}