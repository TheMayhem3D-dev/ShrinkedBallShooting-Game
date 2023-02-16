using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game.Player
{
    public class PlayerShoot : PoolSpawner
    {
        private Bullet bullet;

        public override void Spawn()
        {
            base.Spawn();
            bullet = spawnedGameObject.GetComponent<Bullet>();
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