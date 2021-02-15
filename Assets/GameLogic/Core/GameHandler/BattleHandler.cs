using System.Collections.Generic;

using TestProject.DevOOP.Units;

namespace TestProject.DevOOP.Core
{
    public sealed class BattleHandler
    {
        private IDictionary<UnitType, IList<BaseGameUnit>> _unitsInGame;


        public BattleHandler()
        {
            _unitsInGame = new Dictionary<UnitType, IList<BaseGameUnit>>();
        }

        public void AddUnit(BaseGameUnit unit)
        {
            if(!_unitsInGame.TryGetValue(unit.GetUnitType(), out var list))
            {
                list = new List<BaseGameUnit>();
                _unitsInGame.Add(unit.GetUnitType(), list);
            }
            list.Add(unit);
        }

        public void RemoveUnit(BaseGameUnit unit)
        {
            if(_unitsInGame.TryGetValue(unit.GetUnitType(), out var list))
            {
                if (list.Contains(unit))
                {
                    list.Remove(unit);
                }
            }
        }

        public BaseGameUnit TryGetEnemy(BaseGameUnit unit)
        {
            BaseGameUnit enemy = default;
            foreach(var el in _unitsInGame)
            {
                if(el.Key != unit.GetUnitType())
                {
                    for(int i = 0; i < el.Value.Count; ++i)
                    {
                        if(unit.GetDistanceTo(el.Value[i].SelfTransform.position) <= GameConst.UnitSearchDistance)
                        {
                            enemy = el.Value[i];
                            break;
                        }
                    }
                    if(enemy != default)
                    {
                        break;
                    }
                }
            }
            return enemy;
        }
    }
}