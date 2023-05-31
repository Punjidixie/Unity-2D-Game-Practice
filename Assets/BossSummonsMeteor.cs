using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//takes about 5 seconds
public class BossSummonsMeteor : StateMachineBehaviour
{
    Boss bossScript;


    BossGraphics bossGraphics;

    Vector3 point1Left;
    Vector3 point1Right;
    Vector3 point2Left;
    Vector3 point2Right;
    Vector3 direction1;
    Vector3 direction2;

    float timePassed;
    float meteorsTime1;
    float meteorsTime2;
    float targetLinesTime2;
    
    GameObject targetLine1;
    GameObject targetLine2;
    
    float cycleTime;
    float waitTime;
    int state; //0 is waiting for targetLine, 1 is waiting for meteor
    int countCycles;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        bossScript = animator.gameObject.GetComponentInParent<Boss>();
        bossGraphics = animator.gameObject.GetComponent<BossGraphics>();

        GenerateRandomTargetLines();

        timePassed = 0;
        meteorsTime1 = 2;
        targetLinesTime2 = 4;
        meteorsTime2 = 6;

        cycleTime = 0;
        waitTime = 2;

        countCycles = 0;

        state = 1; //waiting for meteor


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timePassed += Time.deltaTime;
        cycleTime += Time.deltaTime;

        if (countCycles == 2)
        {
            return;
        }
        if (cycleTime >= waitTime)
        {
            switch (state)
            {
                case 0: //waiting for targetLine
                    GenerateRandomTargetLines();
                    state = 1;
                    waitTime = 2;
                    break;
                case 1: //waiting for meteor
                    GenerateMeteors();
                    state = 0;
                    waitTime = 1;
                    countCycles++;
                    break;
                default:
                    break;
            }

            cycleTime = 0;
            
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("SummonsMeteor", false);
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

    void GenerateRandomTargetLines()
    {
        point1Left = new Vector3(-8, Random.Range(-7, 7));
        point1Right = new Vector3(8, Random.Range(-7, 7));
        point2Left = new Vector3(-8, Random.Range(-7, 7));
        point2Right = new Vector3(8, Random.Range(-7, 7));

        targetLine1 = Instantiate(bossScript.targetLinePrefab);
        targetLine1.transform.position = point1Left;
        direction1 = point1Right - point1Left;
        targetLine1.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
        targetLine1.transform.localScale = new Vector3(50, 0.1f, 1);

        targetLine2 = Instantiate(bossScript.targetLinePrefab);
        targetLine2.transform.position = point2Left;
        direction2 = point2Right - point2Left;
        targetLine2.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
        targetLine2.transform.localScale = new Vector3(50, 0.1f, 1);
    }

    //also destroys targetLines
    void GenerateMeteors()
    {
        GameObject meteor1 = Instantiate(bossScript.meteorPrefab);
        meteor1.transform.position = point1Left;
        meteor1.GetComponent<Meteor>().rbGraphics.rotation = Mathf.Atan2(direction1.y, direction1.x) * Mathf.Rad2Deg;
        Destroy(targetLine1);

        GameObject meteor2 = Instantiate(bossScript.meteorPrefab);
        meteor2.transform.position = point2Left;
        meteor2.GetComponent<Meteor>().rbGraphics.rotation = Mathf.Atan2(direction2.y, direction2.x) * Mathf.Rad2Deg;
        Destroy(targetLine2);
    }
}
