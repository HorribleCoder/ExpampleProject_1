namespace TestProject.DevOOP.GamePool
{
    internal interface IGamePool<T>
    {
        void Add(T poolObject);
        T Get(object prototype);
        void Remove(T poolObject);
    }
}