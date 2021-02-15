using System;
using System.Collections;
using UnityEngine;

namespace TestProject.DevOOP.Units.USM
{
    internal sealed class AttackState : BaseState
    {
        public override void EnterState()
        {
            _Debug.Log("Enter - Attack State!");
        }

        public override Type ExecuteState()
        {
            Type resultStateType = this.GetType();
            if (owner.GetDistanceTo(owner.GetEnemyPosition()) > 2f)//1 attak range - test need use config range!!! see agent setup!
            {
                resultStateType = typeof(IdleState);
            }
            return resultStateType;
        }

        public override void ExiteState()
        {
            _Debug.Log("Exit - Attack State!");
        }
    }
}