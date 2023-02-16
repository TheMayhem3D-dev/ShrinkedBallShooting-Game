using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        private GameObject bulletGameObject;
        private Bullet bullet;

        public void SpawnBullet()
        {
            bulletGameObject = ObjectPooler.SpawnFromPool(PoolTag.Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet = bulletGameObject.GetComponent<Bullet>();
            bullet.Reset();
        }

        public void ReleaseBullet()
        {
            if(bullet != null)
                bullet.Release();
        }

        public void IncreaseBullet()
        {
            if(bullet != null)
                bullet.Increase();
        }
    }
}