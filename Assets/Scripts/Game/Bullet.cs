using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    [RequireComponent(typeof(StraightMovement))]
    [RequireComponent(typeof(Scaler))]
    public class Bullet : MonoBehaviour
    {
        private StraightMovement movement;
        private Scaler scaler;

        private void Awake()
        {
            movement = GetComponent<StraightMovement>();
            scaler = GetComponent<Scaler>();
        }

        public void Reset()
        {
            movement.Reset();
        }

        public void Release()
        {
            movement.SetMoveAvailability(true);
        }

        public void Increase()
        {
            scaler.IncreaseScale();
        }
    }
}