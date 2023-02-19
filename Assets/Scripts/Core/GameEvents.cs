using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using Game;
using Game.Player;

namespace Core
{
    public class GameEvents : Singletone<GameEvents>
    {
        public delegate void EventHandler();
        public delegate void EventHandler<X>(X value);

        #region Events

        public event EventHandler onGameOver;
        public event EventHandler onClearRoad;
        public event EventHandler onGameVictory;

        public event EventHandler<PlayerBall> onPlayerBallInitialized;

        #endregion

        #region InitEvents

        void InitEventHandler() { }

        void InitEventHandler<X>(X value) { }

        protected override void Awake()
        {
            Init();
            base.Awake();
        }

        private void Init()
        {
            onGameOver = new EventHandler(InitEventHandler);
            onClearRoad = new EventHandler(InitEventHandler);
            onGameVictory = new EventHandler(InitEventHandler);

            onPlayerBallInitialized = new EventHandler<PlayerBall>(InitEventHandler);
        }

        #endregion

        #region NotifyOnEvent

        public void NotifyOnGameOver() => onGameOver.Invoke();
        public void NotifyOnClearRoad() => onClearRoad.Invoke();
        public void NotifyOnGameVictory() => onGameVictory.Invoke();
        public void NotifyOnPlayerBallInitialized(PlayerBall value) => onPlayerBallInitialized.Invoke(value);

        #endregion
    }
}
