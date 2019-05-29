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
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("hit");
            Vector2 tempVec = (Vector2)transform.position + Vector2.right * 5 * i; // temporary vector = vector 2, positie van de asteroid plus vector 2 right keer 5 keer i
            Instantiate(astroids[i], tempVec, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Split();
        }
    }
}
