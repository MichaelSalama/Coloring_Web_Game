using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimation : MonoBehaviour
{

    public float duration;
    public float speed;
    bool switcher;
    float timer;

    public enum Direction
    {
        Left,
        Right
    }

    public Direction myDirection;

    void Start()
    {
        switcher = false;
       
    }

    void Update()
    {
        //Debug.Log(timer > duration);
        //Debug.Log(duration);

        timer += Time.deltaTime;

        if (timer > duration)
        {
            if (myDirection == Direction.Left)
            {
                myDirection = Direction.Right;
            }
            else if (myDirection == Direction.Right)
            {
                myDirection = Direction.Left;
            }
            timer = 0;
        }
        else
        {
            Move();
        }
     
    }
    private void Move()
    {
        if (myDirection == Direction.Left)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
    }
    
}
