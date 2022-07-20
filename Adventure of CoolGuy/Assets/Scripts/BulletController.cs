using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	[SerializeField] private float bulletSpeed;
	[SerializeField] private float bulletDamage=20;
	[SerializeField] private Rigidbody2D bulletRigidBody;
	



	void Update()
	{
		BulletDirection();
		StartCoroutine(BulletDestroy());

	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		
		if (collision.CompareTag("Enemy"))
		{
			collision.GetComponent<BossHealth>().DealDamage((int)bulletDamage);
			collision.GetComponentInChildren<Animator>().SetBool("IsHurting", true);
			Destroy(this.gameObject);
		}
	}
	private void BulletDirection()
	{
		bulletRigidBody.velocity = transform.right * bulletSpeed;
	}

	IEnumerator BulletDestroy()
	{
		yield return new WaitForSeconds(5f);
		Destroy(this.gameObject);

	}	
}
