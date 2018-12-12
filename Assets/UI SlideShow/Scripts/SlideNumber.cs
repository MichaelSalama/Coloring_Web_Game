using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideNumber : MonoBehaviour {

    public int number;

    public void PickImage(IntVariable skechNumber)
    {
        skechNumber.value = number;
    }
}
