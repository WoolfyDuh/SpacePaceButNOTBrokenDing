using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    private void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyUp(KeyCode.Space)) //Als spatiebalk is ingedrukt
        {
            BulletAttack();
        }
    }

    void BulletAttack()
    {
        GameObject bPrefab = Object.Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject; //Maakt nieuwe bullet van bulletPrefab, quaternion.identity = geen rotatie, is perfect gelijk aan de wereld 
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreLayerCollision(8, 9); // Negeert collision tussen layer 8 (Speler) en layer 9 (Bullets), hierdoor heeft je kogel geen effect op de speler
    }
}