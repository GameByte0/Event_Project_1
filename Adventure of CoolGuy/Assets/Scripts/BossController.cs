using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
	[SerializeField] GameObject playerPrefab;

	[SerializeField] private bool isFlipped = false;

	[SerializeField] private Transform startPoint;




	private int givenDamage = 20;

	public void LookAtPlayer()
	{
		playerPrefab = GameObject.FindGameObjectWithTag("Player");
		Vector2 playerPos = new Vector2(playerPrefab.transform.position.x, playerPrefab.transform.position.y);

		if (playerPos.x > transform.position.x && isFlipped)
		{
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (playerPos.x < transform.position.x && !isFlipped)
		{
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

	public void HitPlayer()
	{
		//Vector2 startPos = transform.position - new Vector3(boxCollider2D.bounds.extents.x + 0.5f, 0, 0);

		RaycastHit2D hit = Physics2D.Raycast(startPoint.position, transform.right, 1f);

		Debug.Log(hit.collider);

		Debug.DrawRay(transform.position, transform.right * 20, Color.blue);


		if (hit.collider.CompareTag("Player")&& hit.collider!=null)
		{
			hit.rigidbody.GetComponent<PlayerHealth>().TakeDamage(givenDamage);
		}
		else
		{
			return;
		}
	}
}
