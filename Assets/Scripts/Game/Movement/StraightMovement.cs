using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class StraightMovement : Movement
    {
        protected override void Move()
        {
            if(canMove)
                rb.MovePosition(transform.position + Vector3.forward * Time.deltaTime * movementSpeed);
        }

        public void Reset()
        {
            rb.velocity = Vector3.zero;
            transform.rotation = Quaternion.identity;
        }
    }
}