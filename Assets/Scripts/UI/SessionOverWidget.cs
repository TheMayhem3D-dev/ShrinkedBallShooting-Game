using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SessionOverWidget : EventEntity
    {
        protected override void Subscribe() { }
        protected override void Unsubcscribe() { }

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