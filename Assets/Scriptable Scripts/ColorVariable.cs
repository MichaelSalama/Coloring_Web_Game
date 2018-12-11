﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewColorVariable",menuName ="Variables/Color",order =1)]
public class ColorVariable : ScriptableObject
{
    //[HideInInspector]
    public Color32 value;

    public void ReSetColor()
    {
        value = Color.white;
    }
}
