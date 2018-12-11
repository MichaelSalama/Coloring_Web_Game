using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public class GameEventListener : MonoBehaviour
    {
        public GameEvent Event;
        public UnityEvent Response;

        public void OnEnable()
        {
            Event.RegisterListner(this);
        }

        private void OnDisable()
        {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
