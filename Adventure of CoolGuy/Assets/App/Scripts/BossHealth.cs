using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
	Animator animator;
	[SerializeField] float bossHealth = 100f;
	
	// Start is called before the first frame update
	void Start()
	{
		animator = gameObject.GetComponentInChildren<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (bossHealth <= 0)
		{
			if (gameObject.name== "Boss_1_Car")
			{
				animator.SetBool("IsCarDestroyed", true);
				

			}
			else
			{
				animator.SetBool("IsDead", true);
			}

		}
	}
	public void DealDamage(int damage)
	{
		bossHealth -= damage;
		Debug.Log(gameObject.name + bossHealth);
	}

	public float ReturnHealth()
	{
		return bossHealth;
	}
}
