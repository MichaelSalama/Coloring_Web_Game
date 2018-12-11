using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentColor : MonoBehaviour {


    public ColorVariable target;

    public Image currentColor;
    
    void Start () {
        currentColor =  GetComponent<Image>();
        currentColor.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        currentColor.color = target.value;
        //currentColor = target.value;		
	}
}
