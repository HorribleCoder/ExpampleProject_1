using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// This class release unit physic.
    /// <para>Use Unity-component <see cref="Rigidbody"/></para>
    /// <para>Use Unity-component <see cref="SphereCollider"/></para>
    /// </summary>
    public sealed class UnitPhysicModule : BaseUnitModule
    {
        //TODO Проверить необходимость событий в модуле физики.
        #region Interface Function
        public override void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            base.AddModule(addEventHandler, owner);
        }

        public override void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
            base.RemoveModule(removeEventHandler);
        }
        #endregion
        protected override void SetupModule(GameObject owner)
        {
            base.SetupModule(owner);
            TryGetComponentInModule<Rigidbody>().useGravity = false;
        }

        protected override Type[] GetRequireComponents()
        {
            return new Type[] { typeof(Rigidbody), typeof(SphereCollider) };
        }
    }
}