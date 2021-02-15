using System;
using UnityEngine;
using UnityEngine.AI;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// This class is unit module for navigation in game.
    /// </summary>
    /// <remarks>Use Unity-component <see cref="NavMeshAgent"/></remarks>
    public sealed class UnitNavigationModule : BaseUnitModule
    {
        #region Override Function
        public override void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            addEventHandler(typeof(Events.UnitMovementEventArgs), MoveToPoint);
            base.AddModule(addEventHandler, owner);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
            removeEventHandler(typeof(Events.UnitMovementEventArgs), MoveToPoint);
            base.RemoveModule(removeEventHandler);
        }

        protected override void SetupModule(GameObject owner)
        {
            base.SetupModule(owner);
            //настраиваем на "быстрый" разворот юнита с учетом скорости передвижения
            var agent = TryGetComponentInModule<NavMeshAgent>();
            agent.angularSpeed = 1200f;
            agent.acceleration = 100f;
            agent.stoppingDistance = 2f;
        }

        protected override Type[] GetRequireComponents()
        {
            return new Type[] { typeof(NavMeshAgent) };
        }
        #endregion

        private void MoveToPoint(object sender, EventArgs eventArgs)
        {
            var message = (Events.UnitMovementEventArgs)eventArgs;
            if (message.MoveSpeed <= GameConst.IdleUnitSpeed) return;
            var agent = TryGetComponentInModule<NavMeshAgent>();
            agent.speed = message.MoveSpeed;
            agent.SetDestination(message.MovePoint);
        }
    }
}