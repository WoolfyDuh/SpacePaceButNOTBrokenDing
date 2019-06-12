using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBorderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D other)
	{

		if (other.CompareTag("Player"))
		{
			float xPos = other.gameObject.transform.position.x;
			other.transform.position = new Vector3(xPos, 290, 0);
			Debug.Log("krijg de tering jamiro");
		}
	}
}
