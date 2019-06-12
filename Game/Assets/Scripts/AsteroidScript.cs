using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{

    public GameObject[] astroids;

    // Start is called before the first frame update
    void Start()
    {
        astroids[0] = Resources.Load<GameObject>("Prefabs/AsteroidPiece1");
        astroids[1] = Resources.Load<GameObject>("Prefabs/AsteroidPiece2");
        astroids[2] = Resources.Load<GameObject>("Prefabs/AsteroidPiece3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Split()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 tempVec = (Vector2)transform.position + Vector2.right * i; // temporary vector
            Instantiate(astroids[Random.Range(0,3)], tempVec, Quaternion.identity);
            Destroy(gameObject);
        }
        for (int i = 0; i < 2; i++)
        {
            Vector2 tempVec = (Vector2)transform.position + Vector2.down + Vector2.right * 2 * i; // temporary vector
            Instantiate(astroids[Random.Range(0,3)], tempVec, Quaternion.identity);
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
