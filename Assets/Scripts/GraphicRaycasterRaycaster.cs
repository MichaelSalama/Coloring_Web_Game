using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class GraphicRaycasterRaycaster : MonoBehaviour
{
    GraphicRaycaster m_Raycaster;
    PointerEventData m_PointerEventData;
    EventSystem m_EventSystem;

    public ColorVariable target;

    void Start()
    {
        m_Raycaster = GetComponent<GraphicRaycaster>();
        m_EventSystem = GetComponent<EventSystem>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            m_PointerEventData = new PointerEventData(m_EventSystem);
            m_PointerEventData.position = Input.mousePosition;

            List<RaycastResult> results = new List<RaycastResult>();

            m_Raycaster.Raycast(m_PointerEventData, results);

            if (hit)
            {
                if (hit.transform.tag == "Picture")
                {
                    Debug.Log(hit.transform.name);
                    hit.transform.gameObject.GetComponent<SpriteRenderer>().color = target.value;
                }
                //Debug.Log(hit.transform.name);
                //target.SetColor(hit.transform.gameObject.GetComponent<SpriteRenderer>().color);
            }

            foreach (RaycastResult result in results)
            {

                if (result.gameObject.tag == "Color")
                {
                    target.SetColor(result.gameObject.GetComponent<Image>().color);
                }

                //Debug.Log("Hit " + result.gameObject.name);
            }

           
        }
    }
}
