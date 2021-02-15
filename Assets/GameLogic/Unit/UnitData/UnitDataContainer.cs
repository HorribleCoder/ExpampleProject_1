using UnityEngine;

using TestProject.DevOOP.Core;

namespace TestProject.DevOOP.Units
{
    internal sealed class UnitDataContainer
    {
        internal UnitType UnitType { get => _unitType; }
        private UnitType _unitType = UnitType.None;
        //TODO запонить контейнер всеми типами данными
        internal Vector3 CurrentMovePoint { get => _currentMovePoint; }
        private Vector3 _currentMovePoint;
        internal int CurrentMovePointIndex { get => _currentMovePointIndex; }
        private int _currentMovePointIndex;
        //attack
        internal BaseGameUnit CurrentEnemy { get => _currentEnemy; }
        private BaseGameUnit _currentEnemy;

        private int _health;

        internal UnitDataContainer(Settings.UnitSettingSO setting)
        {
            _unitType = setting.UnitType;

            ResetUnitData();
        }

        internal void ResetUnitData()
        {
            _currentMovePoint = Vector3.zero;
            _currentMovePointIndex = 0;

            _currentEnemy = default;
            _health = 100;

            UpdateMovementData();
        }

        internal void UpdateMovementData()
        {
            _currentMovePointIndex++;
            _currentMovePoint = Mediator.Instance.GetInstanceByType<NavigationHandler>().GetMovePoint(this);
        }

        #region Attack and Targeting

        internal bool CheckUnitHealth()
        {
            return _health > 0;
        }

        internal void SearchEnemy(BaseGameUnit owner)
        {
            _currentEnemy = Mediator.Instance.GetInstanceByType<BattleHandler>().TryGetEnemy(owner);
        }

        #endregion
    }
}