using UnityEngine;

namespace GameEvents
{
    public class ColorPick : MonoBehaviour
    {
        public ColorVariable target;
        Color32 color;

        private void Awake()
        {
            color = GetComponent<SpriteRenderer>().color;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    Debug.Log(hit.transform.name);
                    GetComponent<GameEventListener>().Event.Raise();
                }
            }
        }

        public void PickColor()
        {
            target.value = color;
        }
    }
}
