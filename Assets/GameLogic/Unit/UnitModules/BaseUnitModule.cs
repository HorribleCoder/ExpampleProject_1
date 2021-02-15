using System;
using UnityEngine;

namespace TestProject.DevOOP.Units.Modules
{
    /// <summary>
    /// Base abstract class all unit module.
    /// </summary>
    /// <remarks>
    /// <para>This class conait Unity Component for need to work module - <see cref="GetRequireComponents"/>.</para>
    /// <para>If need get Unity Component, use function - <see cref="TryGetComponentInModule{T}"/>.</para>
    /// </remarks>
    public abstract class BaseUnitModule : IUnitModule
    {
        
        protected Component[] components;
        /// <summary>
        /// Like - [RequireComponent(typeof(T)]
        /// </summary>
        /// <remarks>Use when create new module unit - <see cref="SetupModule(GameObject)"/></remarks>
        /// <returns>Array type of components.</returns>
        protected abstract Type[] GetRequireComponents();
        #region Virtual Function
        public virtual void AddModule(Action<Type, EventHandler> addEventHandler, GameObject owner)
        {
            SetupModule(owner);
        }
        public virtual void RemoveModule(Action<Type, EventHandler> removeEventHandler)
        {
        }
        /// <summary>
        /// Setup new module.
        /// </summary>
        /// <param name="owner">GameObject owner, default - Unit object.</param>
        protected virtual void SetupModule(GameObject owner)
        {
            var requierComponents = GetRequireComponents();
            components = new Component[requierComponents.Length];
            for(int i = 0; i < requierComponents.Length; ++i)
            {
                if(!GameUtility.TryGetComponentInObject(owner, requierComponents[i], out components[i]))
                {
                    components[i] = owner.AddComponent(requierComponents[i]);
                }
            }
        }
        #endregion
        /// <summary>
        /// Get workable component for a module.
        /// </summary>
        /// <typeparam name="T">Type unity components.</typeparam>
        /// <returns>Unity Component</returns>
        /// <exception cref="System.Exception">No workable component in unit.</exception>
        protected T TryGetComponentInModule<T>()
            where T: Component
        {
            T result = default;
            try
            {
                for(int i =0; i < components.Length; ++i)
                {
                    if(components[i].GetType() == typeof(T))
                    {
                        result = (T)components[i];
                        break;
                    }
                }
                if(result == default)
                {
                    _Debug.Log($"Exeption! В модуле <b>{this.GetType().Name}</b> нет рабочей сслыки на Unity компопнент типа - <b>{typeof(T)}</b> !", DebugColor.red);
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                GameUtility.ExceptionHandler(e);
            }
            return result;
        }
    }
}