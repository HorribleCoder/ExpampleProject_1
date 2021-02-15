using System;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class HuntState : BaseState
    {
        public override void EnterState()
        {
            StateDebug("Enter");
            var arg = GameUtility.GetEventArgByType<UnitMovementEventArgs>();
            arg.MoveSpeed = GameConst.MoveUnitSpeed;
            arg.MovePoint = owner.GetEnemyPosition();
            owner.ExecutUnitEvent(arg);
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();

            if(owner.GetDistanceTo(owner.GetEnemyPosition()) > 2f)//1 attak range - test need use config range!!! see agent setup!
            {
                var arg = GameUtility.GetEventArgByType<UnitMovementEventArgs>();
                arg.MoveSpeed = GameConst.MoveUnitSpeed;
                arg.MovePoint = owner.GetEnemyPosition();
                owner.ExecutUnitEvent(arg);
            }
            else
            {
                resultStateType = typeof(AttackState);
            }

            return resultStateType;
        }

        public override void ExiteState()
        {
            StateDebug("Exit");
            var arg = GameUtility.GetEventArgByType<UnitMovementEventArgs>();
            arg.MovePoint = owner.SelfTransform.position;
            arg.MoveSpeed = GameConst.IdleUnitSpeed;
            owner.ExecutUnitEvent(arg);
        }
    }
}