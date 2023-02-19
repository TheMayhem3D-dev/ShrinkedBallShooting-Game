using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

namespace Game
{
    public class FinishDoor : EventEntity
    {
        private bool isDoorDistCheckActivated;
        private bool doorOpening;
        private Transform ball;
        [Header("Door Properties")]
        [SerializeField] private Transform[] doorPivots;
        [SerializeField] private float minDistanceForOpenDoor;
        [SerializeField] private float[] finalDoorRotation;
        [SerializeField] private float damping = 10;

        protected override void Awake()
        {
            base.Awake();
            SetComponents();
        }

        private void SetComponents()
        {
            if (GameController.instance)
                ball = GameController.instance.playerBall.transform;
        }

        public override void Subscribe()
        {
            if(GameEvents.instance)
                GameEvents.instance.onClearRoad += ActivateDoorDistCheck;
        }

        public override void Unsubscribe()
        {
            if(GameEvents.instance)
                GameEvents.instance.onClearRoad -= ActivateDoorDistCheck;
        }

        private void Update()
        {
            if (isDoorDistCheckActivated)
                ProcessDistanceCheck();

            if (doorOpening)
                ProcessOpenDoor();
        }

        private void ProcessDistanceCheck()
        {
            float dist = Vector3.Distance(ball.position, transform.position);
            if (dist <= minDistanceForOpenDoor)
                StartOpenDoor();
        }

        private void StartOpenDoor()
        {
            isDoorDistCheckActivated = false;
            doorOpening = true;
        }

        private void ProcessOpenDoor()
        {
            for (int i = 0; i < doorPivots.Length; i++)
            {
                var desiredRotQ = Quaternion.Euler(doorPivots[i].eulerAngles.x, finalDoorRotation[i], doorPivots[i].eulerAngles.z);
                doorPivots[i].rotation = Quaternion.Lerp(doorPivots[i].rotation, desiredRotQ, Time.deltaTime * damping);
            }
        }

        private void ActivateDoorDistCheck()
        {
            isDoorDistCheckActivated = true;
        }
    }
}