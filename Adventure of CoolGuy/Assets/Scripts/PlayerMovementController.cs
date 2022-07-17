using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
	[SerializeField] private Rigidbody2D rigidBody;
	[SerializeField] private float playerSpeed;
	[SerializeField] private float jumpForce;
	[SerializeField] private Animator playerAnimator;
	[SerializeField] private bool FacingRight;
 
	private void Update()
	{
		Movement();
		Jump();
	}

	private void Jump()
	{
		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			rigidBody.AddForce(rigidBody.transform.up * jumpForce, ForceMode2D.Impulse);
			
		}
		
	}

	private void Movement()
	{
		float horizontalInput = Input.GetAxis("Horizontal");

		if (horizontalInput>0 && FacingRight)
		{
			PlayerFlip();
		}
		else if (horizontalInput<0 && !FacingRight)
		{
			PlayerFlip();
		}

		//if (horizontalInput!=0)
		//{
		//	transform.localScale = new Vector3(Mathf.Sign(horizontalInput), 1, 1);
		//}

		rigidBody.velocity = new Vector2(horizontalInput * playerSpeed, rigidBody.velocity.y);
		playerAnimator.SetFloat("Horizontal", Mathf.Abs(horizontalInput));

	}
	private void PlayerFlip()
	{
		FacingRight = !FacingRight;
		transform.Rotate(0f, 180f, 0);
	}

	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground"))
		{
			playerAnimator.SetBool("IsJumping", false);
		}
	}
	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.CompareTag("Ground"))
		{
			playerAnimator.SetBool("IsJumping", true);
		}
		
	}

}
