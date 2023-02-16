using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Explosion
    {
        private const string obstacleTag = "Obstacle";

        public void Explode(Vector3 center, float radius)
        {
            Collider[] hitColliders = Physics.OverlapSphere(center, radius);

            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag(obstacleTag))
                {
                    ProcessObstacleCollision(hitCollider);
                }
            }
        }

        private void ProcessObstacleCollision(Collider collider)
        {
            collider.GetComponent<ObstacleVolume>().obstacle.OnExplosionHit();
        }
    }
}