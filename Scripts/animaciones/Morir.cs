using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morir : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BoxCollider boxCollider = animator.gameObject.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            animator.speed = 1.0f;
            Rigidbody rigidbody = animator.gameObject.GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                rigidbody.useGravity = false;
            }

            Destroy(boxCollider);
        }
    }



    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }

   
}
