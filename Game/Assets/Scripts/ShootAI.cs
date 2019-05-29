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
    // Start is called before the first frame update
    void Start()
    {
        inTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inTrigger)
        {
            transform.up = target.position - transform.position;
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
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
            BulletAttack();
            inTrigger = true;
        }
        Physics2D.IgnoreLayerCollision(11, 12);
    }
}
