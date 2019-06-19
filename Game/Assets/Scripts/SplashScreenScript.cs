using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreenScript : MonoBehaviour
{
	public float targetTime = 4f;

	void Update()
	{

		targetTime -= Time.deltaTime;

		if (targetTime <= 0.0f)
		{
			timerEnded();
		}

	}

	void timerEnded()
	{
		SceneManager.LoadScene("Menu");
	}


}



