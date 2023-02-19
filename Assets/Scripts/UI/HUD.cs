using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace UI
{
    public class HUD : EventEntity
    {
        [SerializeField] private SessionOverWidget gameOverWidget;
        [SerializeField] private SessionOverWidget victoryWidget;

        public override void Subscribe()
        {
            if (GameEvents.instance)
            {
                GameEvents.instance.onGameOver += OnGameOver;
                GameEvents.instance.onGameVictory += OnVictory;
            }
        }

        public override void Unsubscribe()
        {
            if (GameEvents.instance)
            {
                GameEvents.instance.onGameOver -= OnGameOver;
                GameEvents.instance.onGameVictory -= OnVictory;
            }
        }

        private void OnGameOver()
        {
            gameOverWidget.ProcessSessionOver();
        }

        private void OnVictory()
        {
            victoryWidget.ProcessSessionOver();
        }
    }
}