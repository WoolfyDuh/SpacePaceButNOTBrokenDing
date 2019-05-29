using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ASSteroidSpawnScript : MonoBehaviour
{
	 //position = Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
	public GameObject asteroid;
	Vector3 position;
	Quaternion rotation;
	float w1;
	float w2;
	float w3;
	float w4;
	// Start is called before the first frame update
	void Start()
	{
		w1 = 2;
		w2 = 4;
		w3 = 6;
		w4 = 8;
		rotation = new Quaternion(w1,w2,w3,w4);
		position = new Vector3(Random.Range(1, 10), Random.Range(1, 10), Random.Range(2,10));
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (Input.GetKeyUp(KeyCode.Return))
		{
			Instantiate(asteroid,position,rotation);
		}
	}
}

