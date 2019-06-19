using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    private bool inTrigger;
    public GameObject player;
    private float speed = 4;
    private float timer = 0;
    private int lives = 5;
    private Animator anim;
    private float animationTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("Ship");
        target = player.transform;
        inTrigger = false;
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isDead")) // als de lives onder 0 zijn, wacht dan 0.5 seconden en destroy dan gameobject
        {
            animationTimer += Time.deltaTime;
            if(animationTimer >= 0.5)
            {
                Destroy(this.gameObject);
            }
        }
        if (inTrigger) // als de speler in de trigger zit, dan kijkt de enemy naar de speler en gaat langzaam naar de speler
        {
            timer += Time.deltaTime;
            transform.up = target.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            if(timer > 2) // Schiet elke 2 seconden naar de speler
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
            Destroy(collision.gameObject);
            if (lives > 0)
            {
                lives--;
            }
            else
            {
                anim.SetBool("isDead", true);
            }
        }
        if(collision.gameObject.tag == "AsteroidPiece")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}