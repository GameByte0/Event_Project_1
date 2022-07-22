using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_1_Walk : StateMachineBehaviour
{	
	[SerializeField] float speed;

	[SerializeField] float attackRange;

	Rigidbody2D rb;

	Transform playerPos;

	BossController boss;

	//OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		playerPos = GameObject.FindGameObjectWithTag("Player").transform;

		rb = animator.GetComponentInParent<Rigidbody2D>();

		boss = animator.GetComponent<BossController>();
	}

	//OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		//Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);

		boss.LookAtPlayer();

		Vector2 target = new Vector2(playerPos.position.x, rb.position.y);

		Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

		rb.MovePosition(newPos);

		if (Vector2.Distance(playerPos.position,rb.position)<=attackRange)
		{
			animator.SetBool("IsAttack",true);
			return;
		}
	}

	//OnStateExit is called when a transition ends and the state machine finishes evaluating this state

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		animator.SetBool("IsAttack",false);
	}


}
