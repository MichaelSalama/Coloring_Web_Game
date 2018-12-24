using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGAnimation : MonoBehaviour
{

    [SerializeField]
    float speed = 5;
    float directionScaler;

    public enum Direction
    {
        Left,
        Right
    }
    public Direction myDirection;

    private void Start()
    {
        if (myDirection == Direction.Left)
        {
            directionScaler = -1;
        }
        else
        {
            directionScaler = 1;
        }
    }
    void Update()
    {
        if (transform.position.x > (Camera.main.transform.position.x + 15))
        {
            transform.position = new Vector3(Camera.main.transform.position.x - 15, transform.position.y,
                transform.position.z);
        }
        else
        {
            transform.Translate(transform.right * directionScaler * speed * Time.deltaTime);
        }
    }
}
