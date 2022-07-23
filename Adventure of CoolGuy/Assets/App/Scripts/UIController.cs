using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
	[Header("UI")]
	[SerializeField] Canvas gameCanvas;
	[SerializeField] Slider playerHealthSlider;
	[SerializeField] Slider bossHealthSlider;
	[SerializeField] Slider bossCarHealthSlider;
	[SerializeField] Canvas gameOverCanvas;
	[SerializeField] Canvas finishCanvas;



	[Header("Characters")]
	[SerializeField] PlayerHealth playerHealth;
	[SerializeField] GameObject bossCar;

	private bool firstBossDefeated = false;

	private void Start()
	{
		gameOverCanvas.gameObject.SetActive(false);
		finishCanvas.gameObject.SetActive(false);
		Time.timeScale = 1;
	}
	private void Update()
	{

		ShowBossCarHealthStatus();

		ShowPlayerHealthStatus();

		Finish();

		GameOver();


	}


	private void ShowPlayerHealthStatus()
	{
		playerHealthSlider.value = playerHealth.ReturnHealth();
	}

	private void ShowBossCarHealthStatus()
	{
		if (bossCar != null && !firstBossDefeated)
		{
			bossCarHealthSlider.value = bossCar.GetComponent<BossHealth>().ReturnHealth();
		}
		else if (bossCar == null)
		{
			firstBossDefeated = true;
		}
	}

	private void Finish()
	{
		if (GameObject.FindObjectOfType<BossHealth>().ReturnHealth() <= 0 && firstBossDefeated)
		{
			finishCanvas.gameObject.SetActive(true);
			StartCoroutine(TimeStop());
		}
	}

	private void GameOver()
	{
		if (playerHealth.ReturnHealth() <= 0)
		{
			gameOverCanvas.gameObject.SetActive(true);
			StartCoroutine(TimeStop());

		}
	}

	IEnumerator TimeStop()
	{
		yield return new WaitForSeconds(0.5f);
		Time.timeScale = 0;
	}
}
