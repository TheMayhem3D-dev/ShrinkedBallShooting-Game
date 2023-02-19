using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public interface IEventListener
    {
        public abstract void Subscribe();
        public abstract void Unsubscribe();
    }
}