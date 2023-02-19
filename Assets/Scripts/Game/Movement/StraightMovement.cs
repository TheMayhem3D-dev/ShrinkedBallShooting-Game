using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StraightMovement : Movement
    {
        private Vector3 movementVector = Vector3.forward;

        protected override void Move()
        {
            if(canMove)
                rb.MovePosition(transform.position + movementVector * Time.deltaTime * movementSpeed);
        }

        public void Reset()
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }

        public void ChangeMovementVector(Vector3 vector)
        {
            movementVector = vector;
        }
    }
}