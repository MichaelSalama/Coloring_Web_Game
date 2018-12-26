using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewImagePicker : MonoBehaviour
{

    public IntVariable sketchNumber;
    public List<GameObject> sketchPrefabs;
    [SerializeField]
    ColorVariable color;
    Painting currentSketch;

    Vector3 pos = new Vector3(7, 0, -0.1f);

    public void ShowSketch()
    {
        GameObject currentSketchObj = Instantiate(sketchPrefabs[sketchNumber.value], pos, Quaternion.identity);
        currentSketch = currentSketchObj.GetComponent<Painting>();
        currentSketchObj.transform.SetParent(this.transform);
        

    }

    public void HideSketch()
    {
        //sketchPrefabs[sketchNumber.value].value = transform.GetChild(0).gameObject;
        transform.GetChild(0).GetComponent<Painting>().Hide();
    }

    public void Whity()
    {
        color.value = Color.white;
    }

    public void ResetToWhite()
    {
        while (currentSketch.paintingAction.Count > 0)
        {
            currentSketch.Undo();
        }
    }

    public void Previuos()
    {
        currentSketch.Undo();
    }
}
