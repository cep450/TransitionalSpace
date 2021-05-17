using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    Animator animator;

    void Start() {
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    public void changePlayerWalk(bool b) {
        animator.SetBool("PlayerWalk", b);
    }

}
