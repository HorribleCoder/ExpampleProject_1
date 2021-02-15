using System;
using UnityEngine;

using TestProject.DevOOP.Units.Events;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// Unit Module for play animation.
    /// </summary>
    /// <remarks>Use Unity-component <see cref="Animator"/></remarks>
    public sealed class UnitVisualModule : BaseUnitModule
    {
        public override void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            addEventHandler(typeof(UnitMovementEventArgs), MovementEventCallback);
            base.AddModule(addEventHandler, owner);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
            removeEventHandler(typeof(UnitMovementEventArgs), MovementEventCallback);
            base.RemoveModule(removeEventHandler);
        }

        private void MovementEventCallback(object sender, EventArgs eventArgs)
        {
            var message = (UnitMovementEventArgs)eventArgs;
            string movementAnim = "Idle";
            if(message.MoveSpeed > GameConst.IdleUnitSpeed)
            {
                movementAnim = "Move";
            }

            UnitPlayAnimation(movementAnim);
        }

        private void UnitPlayAnimation(string animationName, float normalTime = 0f)
        {
            TryGetComponentInModule<Animator>().CrossFade(animationName, normalTime);
        }

        protected override Type[] GetRequireComponents()
        {
            return new Type[] { typeof(Animator) };
        }
    }
}