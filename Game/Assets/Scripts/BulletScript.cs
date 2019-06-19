using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 1000;  
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * speed);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Border" || col.gameObject.tag == "AsteroidPiece")
        {
            Destroy(this.gameObject);
        }
        Physics2D.IgnoreLayerCollision(8, 9);
    }
}
