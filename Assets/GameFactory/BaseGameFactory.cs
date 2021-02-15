using System;
using System.Collections.Generic;

namespace TestProject.DevOOP.Factory
{
    /// <summary>
    /// Main class for all factory in game.
    /// </summary>
    /// <remarks>Use Dictionary of Ctor Prototype-Object.</remarks>
    /// <typeparam name="K">Unique key prototype..</typeparam>
    /// <typeparam name="T">Some type of factory/pool.</typeparam>
    internal abstract class BaseGameFactory<K, T> : IFactory<K, T>
    {
        private IDictionary<K, Func<T>> _prototypeList;

        protected BaseGameFactory()
        {
            _prototypeList = new Dictionary<K, Func<T>>();
        }
        /// <summary>
        /// Invoke contains ctro prototype-object.
        /// </summary>
        /// <param name="key">Unique key of ctor prototype.</param>
        /// <returns>New object.</returns>
        /// <exception cref="System.Exception"> If not contains ctor prototype-object.</exception>
        public virtual T Create(K key)
        {
            T result = default;
            try
            {
                if (!_prototypeList.TryGetValue(key, out var ctor))
                {
                    _Debug.Log($"Exeption! В списке прототипа фабрики <b>{this.GetType().Name}</b> нет прототипа с ключем - <b>{key}</b> / тип - <b>{key.GetType().Name}</b>!", DebugColor.red);
                    throw new Exception();
                }
                result = ctor.Invoke();
            }
            catch (Exception e)
            {
                GameUtility.ExceptionHandler(e);
            }
            return result;
        }
        /// <summary>
        /// Register in list ctor prorotype-object.
        /// </summary>
        /// <param name="key">Unique key prototype.</param>
        /// <param name="value">A ptototype type.</param>
        public virtual void RegisterPrototype(K key, Func<T> value)
        {
            if (!_prototypeList.ContainsKey(key))
            {
                _prototypeList.Add(key, value);
            }
        }
    }
}