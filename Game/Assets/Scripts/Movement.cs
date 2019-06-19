using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private int Lives;
    private float XVelocity;
    private float YVelocity;
    private Vector2 HeldVelocity;
    private Rigidbody2D r2d2;
    private float speedY;
    private float speedX;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Lives = 3;	    //levens
        XVelocity = 30; //draaisnelheid
        YVelocity = 20; //bewegingssnelheid
        r2d2 = GetComponent<Rigidbody2D>(); //rigidbody2D
		speedY = r2d2.velocity.y;
		speedX = r2d2.velocity.x;

	}

    // Update is called once per frame
    void Update()
    {
		Vector3 vel = r2d2.velocity;	
		if (vel.y > 0)
		{
			vel.y -= 0.15f;
            r2d2.velocity = vel;
		}
		if(vel.y < 0)
		{
            vel.y += 0.15f;
			r2d2.velocity = vel;
		}
		if (vel.x > 0)
		{
			vel.x -= 0.18f;
			r2d2.velocity = vel;
		}
		if (vel.x < 0)
		{
			vel.x += 0.18f;
			r2d2.velocity = vel;
		}
	}
	private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {//naar voren gaan
            r2d2.AddForce(transform.up * (YVelocity * 50) * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {//naar achteren gaan
            r2d2.AddForce(transform.up * -(YVelocity * 50) * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        { //naar links draaien
            transform.Rotate(Vector3.forward * -(XVelocity * 3) * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {   //naar rechts draaien
            transform.Rotate(Vector3.forward * (XVelocity * 3) * Time.deltaTime);
        }
        Animate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet")) // haalt een leven eraf
        {
            if (Lives > 0)
            {
                Lives--;
            }
            else if (Lives <= 0)
				SceneManager.LoadScene("End Screen"); //load gewoon direct de scene in plaats van de coroutine doen
        }
    }
    void Animate()
    {
        if (Input.GetKeyDown("w"))
        {
            anim.SetBool("isGoingForward", true);
            anim.SetBool("isGoingLeft", false);
            anim.SetBool("isGoingRight", false);
        }
        if (Input.GetKeyUp("w"))
        {
            anim.SetBool("isGoingForward", false);
            anim.SetBool("isGoingLeft", false);
            anim.SetBool("isGoingRight", false);
        }
        if (Input.GetKeyDown("a"))
        {
            anim.SetBool("isGoingForward", false);
            anim.SetBool("isGoingLeft", true);
            anim.SetBool("isGoingRight", false);
        }
        if (Input.GetKeyUp("a"))
        {
            anim.SetBool("isGoingForward", true);
            anim.SetBool("isGoingLeft", false);
            anim.SetBool("isGoingRight", false);
        }
        if (Input.GetKeyDown("d"))
        {
            anim.SetBool("isGoingForward", false);
            anim.SetBool("isGoingLeft", false);
            anim.SetBool("isGoingRight", true);
        }
        if (Input.GetKeyUp("d"))
        {
            anim.SetBool("isGoingForward", false);
            anim.SetBool("isGoingLeft", false);
            anim.SetBool("isGoingRight", false);
        }
    }
}