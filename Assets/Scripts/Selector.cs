using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{

    public int myNumber;
    public IntVariable imageNumber;

    public void Select()
    {
        imageNumber.value = myNumber;
    }
    
}
