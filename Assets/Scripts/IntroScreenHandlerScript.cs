using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroScreenHandlerScript : MonoBehaviour
{
    public Animator animator;
    public GameObject startButton;
    public GameObject socialGroup;

    private void Start()
    {
        animator.SetBool("Scale", false);
        startButton.SetActive(false);
        socialGroup.SetActive(false);
        StartCoroutine(WaitAnimation());
    }

    IEnumerator WaitAnimation()
    {
        Debug.Log("hena");
        yield return new WaitForSecondsRealtime(3.5f);
        animator.SetBool("Scale", true);
        StartCoroutine(WaitScale());
        Debug.Log("there");
    }
    IEnumerator WaitScale()
    {
        yield return new WaitForSecondsRealtime(1);
        startButton.SetActive(true);
        socialGroup.SetActive(true);
    }
}