using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{

    public List<SpriteRenderer> children;

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).GetComponent<SpriteRenderer>()); 
        }
        Debug.Log("transform.childCount "+ transform.childCount);

        
    }


}
