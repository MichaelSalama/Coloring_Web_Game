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
        sr.color = target.value;
    }
}