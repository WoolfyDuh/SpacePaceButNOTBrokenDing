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
        for (int i = 0; i > 3; i++)
        {
            Debug.Log("hit");
            Vector2 tempVec = (Vector2)transform.position + Vector2.right * i;
            Instantiate(astroids[i], transform.position, Quaternion.identity);
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
