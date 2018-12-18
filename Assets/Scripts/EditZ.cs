using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditZ : MonoBehaviour {

    
    public void RandomSortingLayer()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder=(int) Random.Range(1,31);
        }
    }
    public void SortingZ()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float sortLayer = (float)transform.GetChild(i).GetComponent<SpriteRenderer>().sortingOrder;
            transform.GetChild(i).transform.position = new Vector3(0, 0, -sortLayer / 10);
        }
    }
    public void AddTag()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.tag="Picture";
        }
    }
    public void AddPaintingScript()
    {
        gameObject.AddComponent<Painting>();
    }

    public void AddPolygonCollider()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<PolygonCollider2D>();
        }
    }
}
