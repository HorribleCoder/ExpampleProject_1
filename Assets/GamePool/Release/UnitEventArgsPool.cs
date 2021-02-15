using System;
using System.Collections.Generic;

using TestProject.DevOOP.Factory;

namespace TestProject.DevOOP.GamePool
{
    internal sealed class UnitEventArgsPool : BaseGamePoolList<EventArgs>
    {
        protected override EventArgs GetObjectInPool(object prototype, IList<EventArgs> list)
        {
            EventArgs eventObj = default;
            for(int i = 0; i < list.Count; ++i)
            {
                if(_Equals(list[i], prototype))
                {
                    eventObj = list[i];
                    break;
                }
            }
            return eventObj;
        }

        protected override object CreatePoolObjectByObject(object prototype)
        {
            var eventObj = Mediator.Instance.GetInstanceByType<EventArgsFactory>().Create((Type)prototype);
            Add(eventObj);
            return eventObj;
        }
    }
}