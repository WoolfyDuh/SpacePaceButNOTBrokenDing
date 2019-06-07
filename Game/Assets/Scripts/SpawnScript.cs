using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] private Transform rechterBorder; // Transforms voor alle grenzen
    [SerializeField] private Transform linkerBorder;
    [SerializeField] private Transform bovenBorder;
    [SerializeField] private Transform onderBorder;
    public GameObject charger;
    public GameObject shooter;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
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