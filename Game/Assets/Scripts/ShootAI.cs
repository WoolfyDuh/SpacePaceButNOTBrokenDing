using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    private bool inTrigger;
    public GameObject Player;
    private float speed = 4;
    private float timer = 0;
    private int lives = 5;
    public float lifeTime = 30;
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > lifeTime)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
        if (inTrigger)
        {
            timer += Time.deltaTime;
            transform.up = target.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
            if(timer > 2)
            {
                BulletAttack();
                timer = 0;
            }
        }
        if (!inTrigger)
        {
            timer = 0;
        }
    }
    void BulletAttack()
    {
        Instantiate(bulletPrefab, transform.position, Quaternion.identity); //Maakt nieuwe bullet van bulletPrefab, quaternion.identity = geen rotatie, is perfect gelijk aan de wereld
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inTrigger = true;
        }
        Physics2D.IgnoreLayerCollision(11, 12);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        { 
            if (lives > 0)
            {
                lives--;
            }
            else
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }
}