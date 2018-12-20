using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrayonEffect : MonoBehaviour
{

    Vector3 newPos;
    Vector3 oldPos;
    Color myColor;
    [SerializeField]
    ColorVariable currentColor;

    private void Start()
    {
        oldPos = transform.localPosition;
        newPos = new Vector3(transform.localPosition.x,transform.localPosition.y+.7f, transform.localPosition.z);
        myColor = GetComponent<SpriteRenderer>().color;
    }

    private void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);


        if (hit && hit.transform == this.transform)
        {
            if (transform.position!=newPos)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, newPos, 10f*Time.deltaTime);
            }
            
        }
        else
        {
            if (currentColor.value!=myColor)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, oldPos, 10f * Time.deltaTime);
            }
        }

    }
}
