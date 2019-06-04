using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] Transform rechterborder; // Transforms voor alle grenzen
    [SerializeField] Transform linkerborder;
    [SerializeField] Transform bovenborder;
    [SerializeField] Transform onderborder;
    public GameObject charger;
    public GameObject shooter;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Wait();
    }

    IEnumerator Wait() // functie om te wachten
    {
        SpawnCharger();
        yield return new WaitForSecondsRealtime(30);
        SpawnShooter();
    }

    void SpawnCharger()
    {
        Instantiate(charger, transform.position, Quaternion.identity);
    }
    void SpawnShooter()
    {
        Instantiate(shooter, transform.position, Quaternion.identity);
    }
}