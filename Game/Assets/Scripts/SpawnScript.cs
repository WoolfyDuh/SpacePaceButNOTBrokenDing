using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] Transform rechterborder;
    [SerializeField] Transform linkerborder;
    [SerializeField] Transform bovenborder;
    [SerializeField] Transform onderborder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Debug.Log("Hit!");
            StartCoroutine(Wait());
        }
    }
    IEnumerator Wait()
    {
        Debug.Log("Hit!");
        yield return new WaitForSecondsRealtime(5);
        Debug.Log("5 seconden later!");
    }
}