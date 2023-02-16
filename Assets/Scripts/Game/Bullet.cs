using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

namespace Game
{
    [RequireComponent(typeof(StraightMovement))]
    [RequireComponent(typeof(Scaler))]
    [RequireComponent(typeof(Disabler))]
    public class Bullet : MonoBehaviour
    {
        private StraightMovement movement;
        private Scaler scaler;
        private Disabler disabler;

        [SerializeField] private float lifeTime = 10f;
        private const string obstacleTag = "Obstacle";

        private Vector3 initialScale;

        private void Awake()
        {
            SetComponents();
            SetupProperties();
        }

        private void SetComponents()
        {
            movement = GetComponent<StraightMovement>();
            scaler = GetComponent<Scaler>();
            disabler = GetComponent<Disabler>();
        }

        private void SetupProperties()
        {
            initialScale = transform.localScale;
        }

        public void Reset()
        {
            movement.Reset();
            transform.localScale = initialScale;
        }

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag(obstacleTag))
            {
                ProcessObstacleCollision(collider);
            }
        }

        private void ProcessObstacleCollision(Collider collider)
        {
            collider.GetComponent<ObstacleVolume>().obstacle.OnBulletHit(GetBulletRadius());
            ProcessDisable();
        }

        private float GetBulletRadius()
        {
            return transform.localScale.x;
        }

        public void Increase()
        {
            scaler.IncreaseScale();
        }

        public void Release()
        {
            movement.SetMoveAvailability(true);
            StartCoroutine(StartLifeTimeCounter());
        }

        private IEnumerator StartLifeTimeCounter()
        {
            yield return new WaitForSeconds(lifeTime);
            ProcessDisable();
        }

        private void ProcessDisable()
        {
            disabler.Disable();
        }
    }
}