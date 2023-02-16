using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    public class ShootController : MonoBehaviour
    {
        [SerializeField] private Transform bulletSpawnPoint;
        private GameObject bullet;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                bullet = ObjectPooler.SpawnFromPool(PoolTag.Bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<StraightMovement>().Reset();
            }
            else if(Input.GetMouseButtonUp(0))
            {
                bullet.GetComponent<Bullet>().Release();
            }
        }
    }
}