using UnityEngine;

namespace TestProject.DevOOP.Core
{
    public abstract class MonoSingleton<T> : MonoBehaviour
        where T: MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if(_instance is null)
                {
                    _instance = new GameObject().AddComponent<T>();
                }
                return _instance;
            }
        }

        private static T _instance;

        protected MonoSingleton()
        {
            _Debug.Log($"Create MonoSingleton type = {this.GetType().Name}");
        }
    }
}