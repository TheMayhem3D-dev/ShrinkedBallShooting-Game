using System.Collections;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerShoot))]
    [RequireComponent(typeof(PlayerBall))]
    public class UserInput : MonoBehaviour
    {
        private PlayerShoot shootController;
        private PlayerBall playerBall;

        private void Awake()
        {
            shootController = GetComponent<PlayerShoot>();
            playerBall = GetComponent<PlayerBall>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                shootController.Spawn();
            }
            else if (Input.GetMouseButton(0))
            {
                shootController.IncreaseBullet();
                playerBall.DecreaseBall();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                shootController.ReleaseBullet();
            }
        }
    }
}