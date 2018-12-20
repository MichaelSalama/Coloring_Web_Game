using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePicker : MonoBehaviour
{

    public IntVariable sketchNumber;
    public List<GameObject> sketchPrefabs;
    [SerializeField]
    ColorVariable color;

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

    public void Whity()
    {
        color.value = Color.white;
    }

    public void ResetToWhite()
    {
        foreach (GameObject obj in sketchPrefabs)
        {
            if (obj.activeInHierarchy)
            {
                while (obj.GetComponent<Painting>().paintingAction.Count > 0)
                {
                    obj.GetComponent<Painting>().Undo();
                }

            }
        }
    }

    public void Previuos()
    {
        foreach (GameObject obj in sketchPrefabs)
        {
            if (obj.activeInHierarchy)
            {
                obj.GetComponent<Painting>().Undo();
            }
        }
    }
}
