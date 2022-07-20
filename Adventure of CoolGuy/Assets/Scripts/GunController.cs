using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	[SerializeField] private GameObject bulletPrefab;
	[SerializeField] private float bulletDelay;
	private float nextFireTime;


	private void Update()
	{
		//GunRotation();

		BulletSpawn();
	}

	//private void GunRotation()
	//{
	//	Vector3 mousePosVector = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

	//	mousePosVector.Normalize();

	//	float rotatonZ = Mathf.Atan2(mousePosVector.y, mousePosVector.x) * Mathf.Rad2Deg;

	//	transform.rotation = Quaternion.Euler(0f, 0f, rotatonZ);

	//}
	private void BulletSpawn()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > nextFireTime)
		{
			nextFireTime = Time.time + bulletDelay;


			Instantiate(bulletPrefab, transform.position, transform.rotation);
		}

	}

}
