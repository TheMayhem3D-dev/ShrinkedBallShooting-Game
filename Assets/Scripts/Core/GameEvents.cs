using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace Core
{
    public class GameEvents : Singletone<GameEvents>
    {
        public delegate void EventHandler();
        public delegate void EventHandler<X>(X value);

        #region Events

        public event EventHandler onGameOver;
        public event EventHandler onGameVictory;

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
            onGameVictory = new EventHandler(InitEventHandler);
        }

        #endregion

        #region NotifyOnEvent

        public void NotifyOnGameOver() { onGameOver.Invoke(); }
        public void NotifyOnGameVictory() { onGameVictory.Invoke(); }

        #endregion
    }
}
