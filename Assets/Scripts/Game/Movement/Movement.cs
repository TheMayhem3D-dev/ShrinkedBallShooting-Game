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
        [SerializeField] protected float movementSpeed = 15f;

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

        protected abstract void Move();
    }
}
