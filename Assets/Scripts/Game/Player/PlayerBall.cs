using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game.Player
{
    [RequireComponent(typeof(Scaler))]
    [RequireComponent(typeof(StraightMovement))]
    public class PlayerBall : MonoBehaviour
    {
        private Scaler scaler;
        private StraightMovement straightMovement;

        private Vector3[] raycastOffset;

        [Header("Ball Properties")]
        [SerializeField] private float minimumBallSize = 0.1f;
        private const float ballSpeedFactor = 2f;
        [SerializeField] private GameObject road;

        [Header("Raycast Properties")]
        [SerializeField] private float raycastStep = 0.25f;
        private float minRaycastPosX;
        private float maxRaycastPosX;

        void Awake()
        {
            SetComponents();
            UpdateRaycasts();
            GameEvents.instance?.NotifyOnPlayerBallInitialized(this);
        }

        private void SetComponents()
        {
            scaler = GetComponent<Scaler>();
            straightMovement = GetComponent<StraightMovement>();
        }

        private void UpdateRaycasts()
        {
            UpdateRaycastLimits();

            int raycastCount = GetRaycastCount();
            raycastOffset = new Vector3[raycastCount];

            UpdateRaycastPositions();
        }

        private void UpdateRaycastLimits()
        {
            minRaycastPosX = -(transform.localScale.x / 2);
            maxRaycastPosX = transform.localScale.x / 2;
        }

        private void UpdateRaycastPositions()
        {
            for (int i = 0; i < raycastOffset.Length; i++)
            {
                raycastOffset[i] = new Vector3(transform.localPosition.x + (maxRaycastPosX - (raycastStep * i)),
                    transform.localPosition.y, transform.localPosition.z);
            }
        }

        private int GetRaycastCount()
        {
            float currentPos = maxRaycastPosX;
            int count = 0;

            while (currentPos >= minRaycastPosX)
            {
                currentPos -= raycastStep;
                count++;
            }
            
            return count;
        }

        public void DecreaseBall()
        {
            if (CanDecreaseBall())
            {
                scaler.DecreaseScale();
                UpdateRaycasts();
            }
            else
            {
                GameEvents.instance?.NotifyOnGameOver();
                gameObject.SetActive(false);
                road?.SetActive(false);
            }
        }

        private bool CanDecreaseBall()
        {
            return transform.localScale.x > minimumBallSize;
        }

        void FixedUpdate()
        {
            CheckRoad();
        }

        void CheckRoad()
        {
            if (!IsObstacleOnRoad())
            {
                ReleaseBall();
                road?.SetActive(false);
                GameEvents.instance?.NotifyOnClearRoad();
            }
        }

        private bool IsObstacleOnRoad()
        {
            int layerMask = 1 << 6;

            for (int i = 0; i < raycastOffset.Length; i++)
            {
                RaycastHit hit;
                if (Physics.Raycast(raycastOffset[i], transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
                {
                    Debug.DrawRay(raycastOffset[i], transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    return true;
                }
                else
                    Debug.DrawRay(raycastOffset[i], transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            }

            return false;
        }

        private void ReleaseBall()
        {
            straightMovement.SetSpeed(transform.localScale.x * ballSpeedFactor);
            straightMovement.SetMoveAvailability(true);
        }
    }
}