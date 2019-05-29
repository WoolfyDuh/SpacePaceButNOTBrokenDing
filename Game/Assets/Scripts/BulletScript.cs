using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Vector3 moveDirection;
    [SerializeField]
    private float speed = 2000;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();


        rb = gameObject.GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + moveDirection * speed;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Border")
        {
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag ==  "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        Physics2D.IgnoreLayerCollision(8, 9);
    }
}
