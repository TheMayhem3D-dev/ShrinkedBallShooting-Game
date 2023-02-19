using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class EventEntity : MonoBehaviour
    {
        protected virtual void Awake() => Subscribe();
        protected abstract void Subscribe();

        protected virtual void OnDestroy() => Unsubcscribe();
        protected abstract void Unsubcscribe();
    }
}