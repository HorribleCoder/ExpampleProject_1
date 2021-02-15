using System;
using System.Collections.Generic;

using TestProject.DevOOP.Factory;
using TestProject.DevOOP.GamePool;

namespace TestProject.DevOOP
{
    /// <summary>
    /// This class contain all referense from factory and pool.
    /// </summary>
    /// <remarks>
    /// <para>Don't forget to add the factory/pool object to the list!</para>
    /// Use function - <see cref="SetInstance(object)"/>
    /// </remarks>
    /// <seealso cref="TestProject.DevOOP.Factory.BaseGameFactory{K, T}"/>
    /// <seealso cref="TestProject.DevOOP.GamePool.BaseGamePool{T}"/>
    public sealed class Mediator : IMediator
    {
        public static Mediator Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new Mediator();
                }
                return _instance;
            }
        }

        private static Mediator _instance;

        private Mediator()
        {
            _instanceStorage = new List<object>();

            SetInstance(new ModuleGameFactory());
            SetInstance(new EventArgsFactory());
            SetInstance(new UnitEventArgsPool());
            //добавляем фабрики и прочее, если используем в игре
        }

        private IList<object> _instanceStorage;
        /// <summary>
        /// Function get contains an factory/pool instance.
        /// </summary>
        /// <typeparam name="T">Type a factory/pool.</typeparam>
        /// <returns>Contains <c><b>object</b></c> a factory/pool.</returns>
        public T GetInstanceByType<T>() where T : class
        {
            T currentInstance = default;
            try
            {
                var instanceType = typeof(T);
                for (int i = 0; i < _instanceStorage.Count; ++i)
                {
                    if (_instanceStorage[i].GetType() == instanceType)
                    {
                        currentInstance = (T)_instanceStorage[i];
                        break;
                    }
                }
                if(currentInstance == default)
                {
                    _Debug.Log($"Exeption! В списке объектов Медиатора - <b>{GetType().Name}</b>, нет реализации - <b>{currentInstance.GetType().Name}</b> нужна проверка!", DebugColor.red);
                    throw new Exception();
                }
            }
            catch(Exception e)
            {
                GameUtility.ExceptionHandler(e);
            }
            return currentInstance;
        }
        /// <summary>
        /// Set new <see cref="object"/> a factory/pool in contain list.
        /// </summary>
        /// <param name="poolInstance"></param>
        public void SetInstance(object poolInstance)
        {
            if (_instanceStorage.Contains(poolInstance)) return;
            _instanceStorage.Add(poolInstance);
        }
    }
}