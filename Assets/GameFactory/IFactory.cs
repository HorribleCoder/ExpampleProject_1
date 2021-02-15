using System;

namespace TestProject.DevOOP
{
    internal interface IFactory<K,T>
    {
        void RegisterPrototype(K key, Func<T> value);
        T Create(K key);
    }
}