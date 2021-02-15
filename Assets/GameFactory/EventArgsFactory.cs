using System;
using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Factory
{
    internal sealed class EventArgsFactory : BaseGameFactory<Type, EventArgs>
    {
        internal EventArgsFactory()
        {
            RegisterPrototype(typeof(UnitMovementEventArgs), () => new UnitMovementEventArgs());
        }
    }
}