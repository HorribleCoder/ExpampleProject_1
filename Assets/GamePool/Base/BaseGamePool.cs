namespace TestProject.DevOOP.GamePool
{
    internal abstract class BaseGamePool<T>: IGamePool<T>
    {
        protected BaseGamePool()
        {
            CreateGamePool();
            
        }
        #region Abstract Function
        public abstract void Add(T poolObject);
        public abstract T Get(object prototype);
        public abstract void Remove(T poolObject);
        #endregion

        #region Protected Virtual Function
        protected virtual void CreateGamePool()
        {
            _Debug.Log("Create new Base pool!");
        }

        protected virtual object CreatePoolObjectByObject(object prototype)
        {
            return default;
        }
        #endregion
    }
}