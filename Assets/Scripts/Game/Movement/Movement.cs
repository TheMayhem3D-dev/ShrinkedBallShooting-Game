using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Movement : MonoBehaviour
    {
        protected Rigidbody rb;
        protected bool canMove;
        [SerializeField] protected float movementSpeed;

        protected virtual void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected void FixedUpdate()
        {
            if (canMove)
                Move();
        }

        public void SetMoveAvailability(bool value)
        {
            canMove = value;
        }

        public void SetSpeed(float value)
        {
            movementSpeed = value;
        }

        public float GetSpeed()
        {
            return movementSpeed;
        }

        protected abstract void Move();
    }
}
