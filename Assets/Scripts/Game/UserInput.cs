using System.Collections;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(ShootController))]
    [RequireComponent(typeof(PlayerBall))]
    public class UserInput : MonoBehaviour
    {
        private ShootController shootController;
        private PlayerBall playerBall;

        private void Awake()
        {
            shootController = GetComponent<ShootController>();
            playerBall = GetComponent<PlayerBall>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                shootController.SpawnBullet();
            }
            else if(Input.GetMouseButton(0))
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