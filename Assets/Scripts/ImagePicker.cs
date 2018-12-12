using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePicker : MonoBehaviour {

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
}
