using System.Collections.Generic;
using UnityEngine;

using TestProject.DevOOP.Units;

namespace TestProject.DevOOP.Core
{
    internal struct CapturePointData
    {
        public CaptureNavPoint point;
        public IList<BaseGameUnit> unitList;
        public UnitType currentCaptureType;
        public float captureProgress;
        public float updateTimer;

        public CapturePointData(CaptureNavPoint point)
        {
            this.point = point;
            this.unitList = new List<BaseGameUnit>();
            this.currentCaptureType = UnitType.None;
            this.captureProgress = 0f;
            this.updateTimer = 0f;
        }
    }

    internal sealed class CaptureHandler
    {
        private CapturePointData[] _pointsData;

        internal CaptureHandler()
        {
            var points = GameObject.FindObjectsOfType<CaptureNavPoint>();
            _pointsData = new CapturePointData[points.Length];
            for(int i = 0; i < points.Length; ++i)
            {
                _pointsData[i] = new CapturePointData(points[i]);
            }
        }

        internal bool CheckUnitInCapturePoint(BaseGameUnit unit)
        {
            bool result = false;

            for(int i = 0; i < _pointsData.Length; ++i)
            {
                if(unit.GetDistanceTo(_pointsData[i].point.Position) <= _pointsData[i].point.CaptureRadius)
                {
                    _pointsData[i].unitList.Add(unit);
                    result = true;
                    break;
                }
            }

            return result;
        }

        internal void UpdatePointCaptureStatus()
        {
            //TODO Update capture point status
        }

        internal void ExitPointCapture(BaseGameUnit unit)
        {
            for(int i = 0; i < _pointsData.Length; ++i)
            {
                if (_pointsData[i].unitList.Contains(unit))
                {
                    _pointsData[i].unitList.Remove(unit);
                    break;
                }
            }
        }
    }
}