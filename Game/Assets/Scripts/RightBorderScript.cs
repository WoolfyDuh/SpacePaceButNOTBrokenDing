using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBorderScript : MonoBehaviour
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
		{ float yPos = other.gameObject.transform.position.y;
			other.transform.position = new Vector3(-290,yPos,0);
		}	
	}
}

