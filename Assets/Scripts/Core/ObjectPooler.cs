using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core
{
    public enum PoolTag
    {
        Bullet,
        DestroyFX
    }

    public class ObjectPooler : MonoBehaviour
    {
        [Serializable]
        public class Pool
        {
            public PoolTag tag;
            public GameObject prefab;
            public int size;

            public Transform rootTransform { get; set; }
        }

        public List<Pool> pools;
        public static Dictionary<string, Queue<GameObject>> poolDictionary;

        protected void Awake()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (Pool pool in pools)
            {
                Queue<GameObject> objectPool = new Queue<GameObject>();

                GameObject rootObject = Instantiate(new GameObject(pool.tag.ToString()), transform);
                pool.rootTransform = rootObject.transform;

                for (int i = 0; i < pool.size; i++)
                {
                    GameObject obj = Instantiate(pool.prefab, rootObject.transform);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag.ToString(), objectPool);
            }
        }

        public static GameObject SpawnFromPool(PoolTag poolTag, Vector3 position, Quaternion rotation)
        {
            string tag = poolTag.ToString();

            if (!poolDictionary.ContainsKey(tag))
            {
                throw new Exception("Pool with tag " + tag + " doesn't exist.");
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;
            objectToSpawn.SetActive(true);

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }
    }
}