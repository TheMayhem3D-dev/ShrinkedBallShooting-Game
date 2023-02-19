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

        [SerializeField] private float pauseBeforeDisable = 1f;
        [SerializeField] private Material corruptMaterial;
        [SerializeField] private MeshRenderer obstacleMeshRenderer;

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
            StartCoroutine(Disable());
        }

        public void OnExplosionHit()
        {
            StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            obstacleMeshRenderer.material = corruptMaterial;

            yield return new WaitForSeconds(pauseBeforeDisable);

            disabler.Disable();
        }
    }
}