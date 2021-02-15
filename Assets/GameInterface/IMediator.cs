using System;

namespace TestProject.DevOOP
{
    public interface IMediator
    {
        void SetInstance(object poolInstance);
        T GetInstanceByType<T>() where T: class;
    }
}