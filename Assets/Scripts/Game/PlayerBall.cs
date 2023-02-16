using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Scaler))]
    public class PlayerBall : MonoBehaviour
    {
        private Scaler scaler;

        private void Awake()
        {
            scaler = GetComponent<Scaler>();
        }

        public void DecreaseBall()
        {
            scaler.DecreaseScale();
        }
    }
}