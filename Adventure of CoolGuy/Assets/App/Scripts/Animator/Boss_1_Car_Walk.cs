using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_Car_Walk : StateMachineBehaviour
{
	[SerializeField] GameObject[] patrolPoints;

	[SerializeField] private float carSpeed;

	private GameObject destinationPoint;

	private Rigidbody2D rigidBody;

	private bool isFlip;





	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		patrolPoints = GameObject.FindGameObjectsWithTag("Point");

		destinationPoint = patrolPoints[Random.Range(0, 2)];

		rigidBody = animator.GetComponentInParent<Rigidbody2D>();



	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		Vector2 target = new Vector2(destinationPoint.transform.position.x, rigidBody.position.y);

		Vector2 newPos = Vector2.MoveTowards(rigidBody.position, target, carSpeed * Time.fixedDeltaTime);

		rigidBody.MovePosition(newPos);

		//Debug.Log(rigidBody.position + "" + "" + destinationPoint.transform.position);

		if (Vector2.Distance(rigidBody.transform.position, destinationPoint.transform.position) <= 1f)
		{

			if (destinationPoint == patrolPoints[0])
			{
				destinationPoint = patrolPoints[1];
				Debug.Log("DESTINATION POINT CHANGED TO 1");
			}
			else
			{
				destinationPoint = patrolPoints[0];
				Debug.Log("DESTINATION POINT CHANGED TO 0");
			}

			animator.SetBool("IsIdle", true);

			animator.GetComponent<SpriteRenderer>().flipX = isFlip;

			

		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		isFlip = !isFlip;
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
