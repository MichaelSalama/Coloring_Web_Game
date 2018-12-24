using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{



    void Update()
    {
        transform.localScale = new Vector3((float)Screen.width / 80, (float)Screen.height / 78.66f, 1);

    }
}
