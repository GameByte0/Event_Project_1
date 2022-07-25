using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_CarController : MonoBehaviour
{
  [SerializeField] private int givenDamage;

	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("Player"))
		{
			collision.collider.GetComponent<PlayerHealth>().TakeDamage(givenDamage);
		}
		
	}

}
