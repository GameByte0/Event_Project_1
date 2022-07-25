using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public void Restart()
	{
		SceneManager.LoadScene(1);
		
	}

	public void MainMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void StartGame()
	{
		SceneManager.LoadScene(1);
	}

	public void ExitGame()
	{
		Application.Quit();
	}
}
