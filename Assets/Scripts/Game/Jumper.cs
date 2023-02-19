using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Jumper : MonoBehaviour
    {
        [SerializeField] private Transform minJumpHeightPoint;
        [SerializeField] private Transform maxJumpHeightPoint;

        [SerializeField] private float jumpSpeed = 1.0f;
        [SerializeField] private float fallSpeed = 2.0f;

        private float startTime;
        private float journeyLength;
        private bool isFalling = false;

        void Start()
        {
            ResetTime();
            journeyLength = Vector3.Distance(minJumpHeightPoint.position, maxJumpHeightPoint.position);
            Debug.Log($"journeyLength {journeyLength}");
        }

        void Update()
        {
            if (isFalling)
                ProcessFall();
            else
                ProcessJump();
        }

        private void ProcessJump()
        {
            float speedScaleFactor = transform.parent.localScale.y;
            float distCovered = (Time.time - startTime) * (jumpSpeed / speedScaleFactor);
            float fractionOfJourney = distCovered / journeyLength;

            Lerp(minJumpHeightPoint, maxJumpHeightPoint, fractionOfJourney);
            CheckDistanceCovering(distCovered);
        }

        private void ProcessFall()
        {
            float speedFactor = transform.parent.localScale.y;
            float distCovered = (Time.time - startTime) * (fallSpeed / speedFactor);
            float fractionOfJourney = distCovered / journeyLength;

            Lerp(maxJumpHeightPoint, minJumpHeightPoint, fractionOfJourney);
            CheckDistanceCovering(distCovered);
        }

        private void Lerp(Transform start, Transform end, float distanceFraction)
        {
            transform.position = Vector3.Lerp(start.position, end.position, distanceFraction);
        }

        private void CheckDistanceCovering(float distCovered)
        {
            if (distCovered >= journeyLength)
            {
                isFalling = !isFalling;
                ResetTime();
            }
        }

        private void ResetTime()
        {
            startTime = Time.time;
        }
    }
}