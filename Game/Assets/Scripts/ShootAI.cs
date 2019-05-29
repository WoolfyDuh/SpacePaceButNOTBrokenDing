using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform target;
    private bool inTrigger;
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
        }
    }
    void BulletAttack()
    {
        GameObject bPrefab = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject; //Maakt nieuwe bullet van bulletPrefab, quaternion.identity = geen rotatie, is perfect gelijk aan de wereld
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
