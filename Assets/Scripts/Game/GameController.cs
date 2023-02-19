using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Game.Player;

namespace Game
{
    public class GameController : Singletone<GameController>, IEventListener
    {
        public PlayerBall playerBall { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            Subscribe();
        }

        public void Subscribe()
        {
            if(GameEvents.instance)
                GameEvents.instance.onPlayerBallInitialized += SetPlayerBall;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Unsubscribe();
        }

        public void Unsubscribe()
        {
            if (GameEvents.instance)
                GameEvents.instance.onPlayerBallInitialized -= SetPlayerBall;
        }

        private void SetPlayerBall(PlayerBall value)
        {
            playerBall = value;
        }
    }
}