using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//takes about 6 seconds
public class BossShootFollow : StateMachineBehaviour
{
    Boss bossScript;
    int maxRounds;
    int roundCount;
    float cycleTime;
    float shootPeriod;
    
    BossGraphics bossGraphics;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = animator.gameObject.GetComponentInParent<Boss>();
        bossGraphics = animator.gameObject.GetComponent<BossGraphics>();
        maxRounds = 30;
        roundCount = 0;
        shootPeriod = 0.2f;
        cycleTime = 0;
       
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //control boss direction
        Vector2 direction = bossScript.targetRb.position - bossScript.rb.position;
        bossScript.rbGraphics.rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        cycleTime += Time.deltaTime;

        if (cycleTime >= shootPeriod && roundCount <= maxRounds)
        {
            roundCount++;
            bossGraphics.ShootOneBulletFollow();
            cycleTime = 0;
        } 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("ShootFollow", false);
        bossScript.rbGraphics.rotation = -90;
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
