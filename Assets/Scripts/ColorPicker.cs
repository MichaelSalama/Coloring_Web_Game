using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPicker : MonoBehaviour {

    [SerializeField]
    ColorVariable pickedColor;

    private void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit && hit.transform.tag == "Color")
            {

                pickedColor.value = hit.transform.GetComponent<SpriteRenderer>().color;
            }
        }

    }
}
