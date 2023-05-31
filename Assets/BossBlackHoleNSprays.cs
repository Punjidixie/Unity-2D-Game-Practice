using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//takes about 9 seconds
public class BossBlackHoleNSprays : StateMachineBehaviour
{
    Boss bossScript;
    int maxRounds;
    int roundCount;
    float cycleTime;
    float shootPeriod;
    float timePassed;
    float delayFromBlackHole;
    BossGraphics bossGraphics;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bossScript = animator.gameObject.GetComponentInParent<Boss>();
        bossGraphics = animator.gameObject.GetComponent<BossGraphics>();
        maxRounds = 20;
        roundCount = 0;
        cycleTime = 0;
        shootPeriod = 0.2f;
        timePassed = 0;
        delayFromBlackHole = 5;
        bossGraphics.DropBlackHole();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        cycleTime += Time.deltaTime;
        timePassed += Time.deltaTime;

        if (timePassed >= delayFromBlackHole && cycleTime >= shootPeriod && roundCount <= maxRounds)
        {
            roundCount++;
            bossGraphics.ShootThreeBullets();
            cycleTime = 0;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("BlackHoleNSprays", false);
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