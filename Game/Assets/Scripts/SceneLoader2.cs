using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader2 : MonoBehaviour
{

	public void LoadGame()
	{
		SceneManager.LoadScene("Game");
		Debug.Log("PineApples");
	}
}

