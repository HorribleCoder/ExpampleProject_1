using System.Collections.Generic;
using UnityEngine;

using TestProject.DevOOP.Units;

namespace TestProject.DevOOP.Core
{
    /// <summary>
    /// This class contains and work all movepoint on game field.
    /// </summary>
    public sealed class NavigationHandler
    {
        private IList<Vector3> _gameMovePoint;

        public NavigationHandler()
        {
            FillMovePoint();
        }
        /// <summary>
        /// Find and fill movepoint list.
        /// <para>Use link type - <see cref="GameNavPoint"/></para>
        /// </summary>
        private void FillMovePoint()
        {
            List<GameNavPoint> points = new List<GameNavPoint>(GameObject.FindObjectsOfType<GameNavPoint>());
            int count = points.Count;
            _gameMovePoint = new List<Vector3>();

            //поиск pivot точки
            for (int i = 0; i < points.Count; ++i)
            {
                if (points[i].PointType == PointType.BasePointPlayer)
                {
                    _gameMovePoint.Add(points[i].Position);
                    points.Remove(points[i]);
                    break;
                }
            }
            for (int i = 1; i < count; ++i)
            {
                _gameMovePoint.Add(FindClosestPoint(_gameMovePoint[i - 1]));
            }

            //формируем путь 
            Vector3 FindClosestPoint(Vector3 pivot)
            {
                float minDistance = int.MaxValue;
                float currentDistance = 0f;
                int index = 0;
                for (int i = 0; i < points.Count; ++i)
                {
                    currentDistance = (points[i].Position - pivot).magnitude;
                    if (currentDistance < minDistance)
                    {
                        minDistance = currentDistance;
                        index = i;
                    }
                }
                Vector3 pointPos = points[index].Position;
                points.Remove(points[index]);
                return pointPos;
            }
        }
        /// <summary>
        /// Get target movepoint for unit by unit type - <see cref="UnitType"/>
        /// </summary>
        /// <param name="unitData">Current unit data.</param>
        /// <returns>Movepoint coordinate <see cref="Vector3"/></returns>
        internal Vector3 GetMovePoint(UnitDataContainer unitData)
        {
            Vector3 point = Vector3.zero;
            if(unitData.UnitType == UnitType.Player)
            {
                point = GetMovePointByIndexPlayer(unitData.CurrentMovePointIndex);
            }
            else
            {
                point = GetMovePointByIndexEnemy(unitData.CurrentMovePointIndex);
            }
            Vector3 RandomDeltaRange()
            {
                Vector3 deltaPoint = Vector3.one * Random.Range(-1.25f, 1.25f);//melee range attack
                deltaPoint.y = point.y;
                return deltaPoint;
            }

            return point + RandomDeltaRange();
        }

        private Vector3 GetMovePointByIndexPlayer(int index)
        {

            if(index >= _gameMovePoint.Count)
            {
                index = _gameMovePoint.Count - 1;
            }
            return _gameMovePoint[index];
        }


        private Vector3 GetMovePointByIndexEnemy(int index)
        {
            index = _gameMovePoint.Count - index - 1;
            if (index < 0)
            {
                index = 0;
            }
            return _gameMovePoint[index];
        }
    }
}