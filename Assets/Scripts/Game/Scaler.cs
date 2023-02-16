using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Scaler : MonoBehaviour
    {
        [SerializeField] private float scaleSpeed = 1f;
        [SerializeField] private float scaleFactor = 0.1f;

        public void IncreaseScale()
        {
            transform.localScale += GetScaleStep();
        }

        public void DecreaseScale()
        {
            transform.localScale -= GetScaleStep();
        }

        private Vector3 GetScaleStep()
        {
            return new Vector3(scaleFactor, scaleFactor, scaleFactor) * (scaleSpeed * Time.deltaTime);
        }
    }
}