using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPieceScript : MonoBehaviour
{
    Vector2 direction;
    float force;
    float x;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        y = Random.Range(-1000, 1000);
        x = Random.Range(-1000, 1000);
        direction = new Vector2(y, x);
        GetComponent<Rigidbody2D>().AddForce(direction);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 14);
        Physics2D.IgnoreLayerCollision(14, 15);
        Physics2D.IgnoreLayerCollision(14, 16);
        Physics2D.IgnoreLayerCollision(15, 16);
    }
}
