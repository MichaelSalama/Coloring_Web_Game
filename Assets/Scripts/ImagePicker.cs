using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePicker : MonoBehaviour
{

    public IntVariable sketchNumber;
    public List<GameObject> sketchPrefabs;


    public void ShowSketch()
    {
        foreach (GameObject obj in sketchPrefabs)
        {
            obj.SetActive(false);
        }
        sketchPrefabs[sketchNumber.value].SetActive(true);
    }

    public void HideSketch()
    {
        foreach (GameObject obj in sketchPrefabs)
        {
            obj.SetActive(false);
        }
    }

    public void ResetToWhite()
    {
        foreach (GameObject obj in sketchPrefabs)
        {
            if (obj.activeInHierarchy)
            {
                for (int i = 0; i < obj.transform.childCount; i++)
                {
                    obj.GetComponent<Painting>().children[i].color = Color.white;
                }
            }
        }
    }
}
