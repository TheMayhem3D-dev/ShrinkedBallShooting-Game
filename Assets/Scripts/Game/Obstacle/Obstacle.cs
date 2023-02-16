using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Disabler))]
    public class Obstacle : MonoBehaviour
    {
        private Disabler disabler;
        private Explosion explosion;

        private void Awake()
        {
            SetComponents();
        }

        private void SetComponents()
        {
            disabler = GetComponent<Disabler>();
            explosion = new Explosion();
        }

        public void OnBulletHit(float radius)
        {
            explosion.Explode(transform.position, radius);
            disabler.Disable();
        }

        public void OnExplosionHit()
        {
            disabler.Disable();
        }
    }
}