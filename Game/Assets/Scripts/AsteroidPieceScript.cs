using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidPieceScript : MonoBehaviour
{
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(90, 100);
        GetComponent<Rigidbody2D>().AddRelativeForce(Random.onUnitSphere * speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 14);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
