using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    public ColorVariable target;
    SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f) && hit.transform.tag == "Picture")
            {
                Debug.Log(hit.transform.name);
                sr.color = target.value;
            }
        }
    }
}
