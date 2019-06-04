using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] Transform rechterborder; // Transforms voor alle grenzen
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

    IEnumerator Wait() // functie om te wachten
    {

        yield return new WaitForSecondsRealtime(30);
        
    }

    void SpawnCharger()
    {
    }
    void SpawnShooter()
    {

    }
}