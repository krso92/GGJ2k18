using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationHandler : MonoBehaviour
{

    public Animator animator;

    // Use this for initialization
    void Start()
    {

    }

    public void PlayWalkAnimation()
    {
        animator.SetTrigger("walk");
    }

    public void PlayIdleAnimation()
    {
        animator.SetTrigger("idle");
    }
}
