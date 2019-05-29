using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private int Lives;
    [SerializeField] private float XVelocity;
    [SerializeField] private float YVelocity;
    Vector2 HeldVelocity;
    Rigidbody2D r2d2;
    [SerializeField] private Vector2 spawnpos;
    // Start is called before the first frame update
    void Start()
    {
        spawnpos = transform.position;
        Lives = 3;	   //DIT IS ONZE LEVENS BOI
        XVelocity = 100; //DIT IS ONZE ROTATION BOI
        YVelocity = 25; //DIT IS ONZE MOVEMENT BOI
        r2d2 = GetComponent<Rigidbody2D>(); //DIT IS ONZE RIGIDBOI
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        //MOVEMENT forward
        if (Input.GetKey("w"))
        {
            r2d2.AddForce(transform.up * (YVelocity * 50) * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {//MOVEMENT BACKWARD
            r2d2.AddForce(transform.up * -(YVelocity * 50) * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        { //MOVEMENT LEFT
            transform.Rotate(Vector3.forward * -(XVelocity * 3) * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {   //MOVEMENT RIGHTO
            transform.Rotate(Vector3.forward * (XVelocity * 3) * Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        { //DIT HOORT DE SHIT TE STOPPEN ALS DIE EEN ENEMY AANRACKT
            r2d2.velocity = Vector3.zero;
            if (Lives > 0)
            {
                Lives--;
            }
            else if (Lives <= 0){
                StartCoroutine(LoadYourAsyncScene());
            }
            else
            {
                Reset();
            }
        }
    }
    private void Reset()
    {
        transform.position = spawnpos;
    }
	IEnumerator LoadYourAsyncScene()
	{   
		// The Application loads the Scene in the background as the current Scene runs.
		// This is particularly good for creating loading screens.
		// You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
		// a sceneBuildIndex of 1 as shown in Build Settings.

		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("End Screen");

		// Wait until the asynchronous scene fully loads
		while (!asyncLoad.isDone)
		{
			yield return null;
		}
	}
}
