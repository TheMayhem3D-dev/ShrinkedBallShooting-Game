using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ObstacleVolume : MonoBehaviour
    {
        public Obstacle obstacle { get; private set; }

        private void Awake()
        {
            SetComponents();
        }

        private void SetComponents()
        {
            obstacle = GetComponentInParent<Obstacle>();
        }
    }
}