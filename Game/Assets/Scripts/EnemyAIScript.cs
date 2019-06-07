using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    private Vector3 startPos;
    private GameObject Player;
    private float speed;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        speed = 4;
        startPos = transform.position;
        if (!Player)
        {
            Player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.up = target.position - transform.position;
        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
