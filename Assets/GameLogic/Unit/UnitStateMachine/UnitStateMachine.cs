using System;
using System.Collections.Generic;

namespace TestProject.DevOOP.Units.USM
{
   internal sealed class UnitStateMachine : IUnitStateMachine<BaseGameUnit>
    {
        internal static UnitStateMachine Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new UnitStateMachine();
                }
                return _instance;
            }
        }

        private static UnitStateMachine _instance;

        private IList<IState<BaseGameUnit>> _stateList;

        internal UnitStateMachine()
        {
            _stateList = new List<IState<BaseGameUnit>>()
            {
                new IdleState(),
                new MoveState(),
                new HuntState(),
                new AttackState()
            };
            //nb add all unit states
        }

        public IState<BaseGameUnit> ProcessUSM(IState<BaseGameUnit> currenState, BaseGameUnit sender)
        {
            //new unit sender
            if(currenState == default)
            {
                currenState = GetStateInList(typeof(IdleState));
            }
            //main process
            currenState.SetUnitOwner(sender);
            var stateResultType = currenState.ExecuteState();
            if(currenState.GetType() != stateResultType)
            {
                currenState.ExiteState();
                currenState = GetStateInList(stateResultType);
                currenState.SetUnitOwner(sender);
                currenState.EnterState();
            }
            return currenState;
        }

        private IState<BaseGameUnit> GetStateInList(Type stateType)
        {
            //TODO Сделать - если нет доступного состояни, то переводим в Idle!
            IState<BaseGameUnit> result = default;
            for(int i = 0; i < _stateList.Count; ++i)
            {
                if(_stateList[i].GetType() == stateType)
                {
                    result = _stateList[i];
                    break;
                }
            }
            if(result == default)
            {
                result = GetStateInList(typeof(IdleState));
            }
            return result;
        }
    }
}