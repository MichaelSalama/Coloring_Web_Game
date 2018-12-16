using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{

    public struct ReverseGroup
    {
        public Transform spriteTransform;
        public Color spriteColor;
    }

    public Stack<ReverseGroup> paintingAction = new Stack<ReverseGroup>();

    [HideInInspector]
    public List<SpriteRenderer> children;

    [SerializeField]
    ColorVariable pickedColor;

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            children.Add(transform.GetChild(i).GetComponent<SpriteRenderer>());
        }


    }

    private void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (hit && hit.transform.tag == "Picture")
            {

                if (hit.transform.gameObject.GetComponent<SpriteRenderer>().color != pickedColor.value)
                {
                    ReverseGroup rg;
                    rg.spriteTransform = hit.transform;
                    rg.spriteColor = hit.transform.gameObject.GetComponent<SpriteRenderer>().color;

                    paintingAction.Push(rg);
                    hit.transform.gameObject.GetComponent<SpriteRenderer>().color = pickedColor.value;
                }

            }
        }

    }

    public void Undo()
    {
        if (paintingAction.Count > 0)
        {
            ReverseGroup undo = paintingAction.Pop();
            undo.spriteTransform.GetComponent<SpriteRenderer>().color = undo.spriteColor;
        }

    }

}
