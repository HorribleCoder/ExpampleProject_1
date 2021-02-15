using System.Collections.Generic;

namespace TestProject.DevOOP.GamePool
{
    internal abstract class BaseGamePoolHashTable<K,T> : BaseGamePool<T>
    {
        private IDictionary<K, Queue<T>> _poolTable;

        internal BaseGamePoolHashTable() : base()
        {
            
        }

        protected override void CreateGamePool()
        {
            _poolTable = new Dictionary<K, Queue<T>>();
            _Debug.Log("Create new Base HASH Table pool!");
        }
        public override void Add(T poolObject)
        {
            if(!_poolTable.TryGetValue(GetPoolObjectKey(poolObject), out var currentTable))
            {
                currentTable = new Queue<T>();
            }
            currentTable.Enqueue(poolObject);
        }

        public override T Get(object prototype)
        {
            T poolObject = default;

            if(!_poolTable.TryGetValue(GetPoolObjectKey(prototype), out var currentTable))
            {
                poolObject = (T)CreatePoolObjectByObject(prototype);
            }
            else
            {
                poolObject = currentTable.Dequeue();
            }
            return poolObject;
        }

        public override void Remove(T poolObject)
        {
            if(_poolTable.TryGetValue(GetPoolObjectKey(poolObject), out var currentTable))
            {
                currentTable.Dequeue();
            }
        }

        protected abstract K GetPoolObjectKey(object poolObject);
    }
}