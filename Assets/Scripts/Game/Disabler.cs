using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Disabler : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }
    }
}