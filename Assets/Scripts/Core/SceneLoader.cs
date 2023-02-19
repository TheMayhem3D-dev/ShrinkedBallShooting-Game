using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string sceneNameToLoad;
        [SerializeField] private bool loadOnStart;

        private void Start()
        {
            if (loadOnStart)
                LoadScene();
        }

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }
    }
}