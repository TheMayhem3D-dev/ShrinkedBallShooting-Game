using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class PoolSpawner : MonoBehaviour
    {
        [SerializeField] protected PoolTag poolTag;

        [SerializeField] protected Transform spawnPoint;
        protected GameObject spawnedGameObject;

        public virtual void Spawn()
        {
            spawnedGameObject = ObjectPooler.SpawnFromPool(poolTag, spawnPoint.position, spawnPoint.rotation);
        }
    }
}