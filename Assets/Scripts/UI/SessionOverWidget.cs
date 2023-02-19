using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SessionOverWidget : EventEntity
    {
        public override void Subscribe() { }
        public override void Unsubscribe() { }

        public void ProcessSessionOver()
        {
            gameObject.SetActive(true);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}