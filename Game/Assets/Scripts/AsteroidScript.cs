using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public GameObject[] astroids;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Split()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 tempVec = (Vector2)transform.position + Vector2.right * 5 * i; // temporary vector = vector 2, positie van de asteroid plus vector 2 right keer 5 keer i
            Instantiate(astroids[i], tempVec, Quaternion.identity);
            Destroy(gameObject);
        }
        for (int i = 0; i < 2; i++)
        {
            Vector2 tempVec = (Vector2)transform.position + Vector2.down * 5 + Vector2.right * 5 * i; // temporary vector = vector 2, positie van de asteroid plus vector 2 right keer 5 keer i
            Instantiate(astroids[i], tempVec, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Split();
        }
    }
}
