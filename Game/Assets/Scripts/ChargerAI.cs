using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargerAI : MonoBehaviour
{
    private Vector3 startPos;
    private GameObject Player;
    private float speed;
    public Transform target;
    private Animator anim;
    private float animTimer;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
        speed = 8;
        startPos = transform.position;
        target = Player.transform;
        anim.SetBool("isDead", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("isDead")) // Kijkt of de charger dood is
        {
            animTimer += Time.deltaTime;
            if(animTimer >= 0.5)
            {
                Destroy(this.gameObject); // wacht 0.5 seconden voordat hij de charger verwijderd
            }
        }
        transform.up = target.position - transform.position; // Charger kijkt naar speler
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime); // beweegt charger naar speler
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Border")
        {

            Destroy(this.gameObject);

        }
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            boolTrue();
        }
        if (collision.gameObject.tag == "AsteroidPiece")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
    void boolTrue()
    {
        anim.SetBool("isDead", true);
    }
}
