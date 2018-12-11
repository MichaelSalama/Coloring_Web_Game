﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ColorVariable target;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                Debug.Log(hit.transform.name);
                target.SetColor(hit.transform.gameObject.GetComponent<SpriteRenderer>().color);
            }

        }
    }

    private void OnDisable()
    {
        target.ReSetColor();
    }
}
