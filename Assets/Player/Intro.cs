using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    [SerializeField] float seconds = 2f;
    Animator animator;
    public void Start(){
        animator = GetComponent<Animator>();
        animator.SetBool("Intro", true);
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(seconds);
        animator.SetBool("Intro", false);
    }
}
