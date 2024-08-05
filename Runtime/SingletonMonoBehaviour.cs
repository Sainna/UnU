using UnityEngine;
using System;

namespace Sainna.Utils
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {

        [SerializeField] bool _DontDestroyGameobjectOnLoad = false;

        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    Type t = typeof(T);

                    instance = (T)FindObjectOfType(t);
                    if (instance == null)
                    {
                        Debug.LogError($"{t} is not attached to any GameObjects");
                    }
                }

                return instance;
            }
        }

        virtual protected void Awake()
        {
            CheckInstance();
        }

        protected bool CheckInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                if (_DontDestroyGameobjectOnLoad)
                    DontDestroyOnLoad(gameObject);
                return true;
            }
            else if (Instance == this)
            {
                return true;
            }

            if (_DontDestroyGameobjectOnLoad)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(this);
            }

            return false;
        }
    }
}