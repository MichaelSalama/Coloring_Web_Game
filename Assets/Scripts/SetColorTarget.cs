using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorTarget : MonoBehaviour
{
    public ColorVariable target;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        target.value = sr.color;
    }
}
