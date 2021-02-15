using UnityEngine;
using TestProject.DevOOP.Units.USM;

namespace TestProject.DevOOP.Units
{
    public abstract partial class BaseGameUnit : IUpdatable
    {
        private UnitDataContainer _unitData;
        private IState<BaseGameUnit> _curentState;

        private void Start()
        {
            _unitData = new UnitDataContainer(_unitSetting);

            UnitStart();
        }

        #region Absttract Function
        public abstract void OnFixedUpdate();
        public abstract void OnUpdate();
        #endregion

        private void Update()
        {
            _curentState = UnitStateMachine.Instance.ProcessUSM(_curentState, this);
        }

        #region Main Function

        internal void UnitStart()
        {
            GameUtility.RegisterUnitInGame(this);
        }

        internal UnitType GetUnitType()
        {
            return _unitData.UnitType;
        }

        internal bool CheckActiveStatus()
        {
            return _unitData.CheckUnitHealth();
        }
        #endregion

        #region Movement Function
        internal void MovementComplite()
        {
            _unitData.UpdateMovementData();
        }

        internal float GetDistanceTo()
        {
            return (_unitData.CurrentMovePoint - this.SelfTransform.position).magnitude;
        }

        internal float GetDistanceTo(Vector3 point)
        {
            return (point - this.SelfTransform.position).magnitude;
        }

        internal Vector3 GetMovePoint()
        {
            return _unitData.CurrentMovePoint;
        }
        #endregion

        #region Attack Enemy
        internal bool CheckCloserEnemy()
        {
            _unitData.SearchEnemy(this);
            return !(_unitData.CurrentEnemy is null);
        }

        internal Vector3 GetEnemyPosition()
        {
            return _unitData.CurrentEnemy.SelfTransform.position;
        }
        #endregion
    }
 }