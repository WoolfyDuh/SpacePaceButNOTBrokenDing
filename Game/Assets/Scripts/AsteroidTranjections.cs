using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidTranjections : MonoBehaviour
{
	public GameObject prefab;
	Random random = new Random();
	//int RandomNumber = random.Next(1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Ra(0,100) > 10)
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(this.gameObject);
            
        }
    }
}
