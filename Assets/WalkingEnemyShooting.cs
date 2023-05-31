using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingEnemyShooting : StateMachineBehaviour
{
    WalkingEnemy walkingEnemyScript;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        walkingEnemyScript = animator.gameObject.GetComponentInParent<WalkingEnemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 direction = walkingEnemyScript.target.transform.position - walkingEnemyScript.transform.position;
        float distance = direction.magnitude;
        walkingEnemyScript.rbGraphics.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        walkingEnemyScript.rb.velocity = Vector2.zero;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("Shooting", false);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
