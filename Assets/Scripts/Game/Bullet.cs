using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Game
{
    [RequireComponent(typeof(StraightMovement))]
    public class Bullet : MonoBehaviour
    {
        private StraightMovement movement;

        private void Awake()
        {
            movement = GetComponent<StraightMovement>();
        }

        public void Release()
        {
            movement.SetMoveAvailability(true);
        }
    }
}