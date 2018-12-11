using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorTarget : MonoBehaviour
{
    public ColorVariable target;
    //Renderer sr;
    public Color32 my_color;
    private void Awake()
    {
        my_color = GetComponent<SpriteRenderer>().color;
        //sr = GetComponent<renderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.tag == "Picker")
                {
                Debug.Log(hit.transform.name);
                // StartCoroutine(ColorSet());
                target.value = my_color;
                }
                else if (hit.transform.tag == "Picture")
                {
                Debug.Log(hit.transform.name);
                    
                }
            }

        }
    }

    private void OnDisable()
    {
        target.ReSetColor();
    }

    //IEnumerator ColorSet()
    //{
    //    Debug.Log("Coroutine");
    //    yield return new WaitForEndOfFrame();
    //}
}
