using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T globalInstance;

        private static bool isDestroying = false;

        private static object locker = new object();

        public static T instance
        {
            get
            {
                lock (locker)
                {
                    if (globalInstance == null && !isDestroying)
                    {
                        T[] objects = FindObjectsOfType(typeof(T)) as T[];
                        if (objects != null && objects.Length > 0)
                        {
                            globalInstance = objects[0];

                            if (objects.Length > 1)
                            {
                                for (int i = 1; i < objects.Length; i++)
                                {
                                    DestroyImmediate(objects[i]);
                                }
                            }
                        }
                        else
                        {
                            GameObject go = new GameObject(typeof(T).Name, typeof(T));
                            globalInstance = go.GetComponent<T>();
                        }
                    }


                    return globalInstance;
                }
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            isDestroying = true;
            globalInstance = null;
        }
    }
}