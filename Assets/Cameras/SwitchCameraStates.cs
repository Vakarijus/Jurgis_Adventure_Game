using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCameraStates : MonoBehaviour
{
    [SerializeField] float seconds = 2f;
    Animator animator;
    public void Start(){
        animator = GetComponent<Animator>();
        StartCoroutine(Animation());
    }
    IEnumerator Animation()
    {
        yield return new WaitForSeconds(seconds);
        SwitchState();
    }

    void SwitchState()
    {
        animator.Play("FollowCamera");
    }
}
