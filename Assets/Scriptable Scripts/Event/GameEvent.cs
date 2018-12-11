using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameEvents
{
    [CreateAssetMenu(fileName = "NewGameEVent", menuName = "Events/GameEvent", order = 1)]
    public class GameEvent : ScriptableObject
    {
        private List<GameEventListener> listeners = new List<GameEventListener>();

        public void Raise()
        {
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised();
            }
        }

        public void RegisterListner(GameEventListener listener)
        {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
            else
                Debug.Log("Listener registered to event.");
        }

        public void UnregisterListener(GameEventListener listener)
        {
            listeners.Remove(listener);
        }

    }
}
