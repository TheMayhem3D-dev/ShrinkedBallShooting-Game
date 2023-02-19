using System.Collections;
using UnityEngine;
using Core;

namespace Game.Player
{
    [RequireComponent(typeof(PlayerShoot))]
    [RequireComponent(typeof(PlayerBall))]
    public class UserInput : EventEntity
    {
        private PlayerShoot shootController;
        private PlayerBall playerBall;

        private bool isInputActive = true;

        protected override void Awake()
        {
            base.Awake();
            SetComponents();
        }

        public override void Subscribe()
        {
            if (GameEvents.instance)
            {
                GameEvents.instance.onGameOver += OnSessionOver;
                GameEvents.instance.onClearRoad += OnSessionOver;
                GameEvents.instance.onGameVictory += OnSessionOver;
            }
        }

        public override void Unsubscribe()
        {
            if (GameEvents.instance)
            {
                GameEvents.instance.onGameOver -= OnSessionOver;
                GameEvents.instance.onClearRoad -= OnSessionOver;
                GameEvents.instance.onGameVictory -= OnSessionOver;
            }
        }

        private void SetComponents()
        {
            isInputActive = true;
            shootController = GetComponent<PlayerShoot>();
            playerBall = GetComponent<PlayerBall>();
        }

        private void Update()
        {
            if (isInputActive)
                ProcessInput();
        }

        private void ProcessInput()
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

        private void OnSessionOver()
        {
            isInputActive = false;
        }
    }
}