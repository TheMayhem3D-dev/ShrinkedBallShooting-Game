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

        protected override void Subscribe()
        {
            if (GameEvents.instance)
            {
                GameEvents.instance.onGameOver += OnGameOver;
                GameEvents.instance.onGameVictory += OnVictory;
            }
        }

        protected override void Unsubcscribe()
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