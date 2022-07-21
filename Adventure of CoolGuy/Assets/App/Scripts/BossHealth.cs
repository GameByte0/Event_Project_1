using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
  [SerializeField] Animator animator;
  [SerializeField] float bossHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (bossHealth<=0)
		{
      animator.SetBool("IsCarDestroyed",true);
		}
    }
  public void DealDamage(int damage)
	{
    bossHealth -= damage;
	}

  public float ReturnHealth()
	{
    return bossHealth;
	}
}
