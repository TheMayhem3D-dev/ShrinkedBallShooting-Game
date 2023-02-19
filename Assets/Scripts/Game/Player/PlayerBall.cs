using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Scaler))]
    public class PlayerBall : MonoBehaviour
    {
        private Scaler scaler;

        private Vector3[] raycastOffset;

        [Header("Raycast Properties")]
        [SerializeField] private float raycastStep = 0.25f;
        private float minRaycastPosX;
        private float maxRaycastPosX;

        private void Awake()
        {
            scaler = GetComponent<Scaler>();
            UpdateRaycasts();
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
            scaler.DecreaseScale();
            UpdateRaycasts();
        }

        void FixedUpdate()
        {
            CheckRoad();
        }

        void CheckRoad()
        {
            if (!IsObstacleOnRoad())
            {
                Debug.Log("Victory");
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
    }
}