﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    [SerializeField] private Transform rightBorder; // Transforms voor alle grenzen
    [SerializeField] private Transform leftBorder;
    [SerializeField] private Transform topBorder;
    [SerializeField] private Transform botBorder;
    public GameObject charger;
    public GameObject shooter;
    public GameObject asteroid;
    private GameObject border;
    private float timer = 0;
    private float timer2 = 0;
    private float timer3 = 0;
    private GameObject[] chargerCount;
    private int chargerAmount;
    private GameObject[] shooterCount;
    private int shooterAmount;
    private GameObject[] asteroidCount;
    private int asteroidAmount;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
        border = GameObject.Find("Bovengrens"); // Geeft elke transform de waarde van de borders' transform
        topBorder = border.transform;
        border = GameObject.Find("Rechtergrens");
        rightBorder = border.transform;
        border = GameObject.Find("Ondergrens");
        botBorder = border.transform;
        border = GameObject.Find("Linkergrens");
        leftBorder = border.transform;
        charger = Resources.Load<GameObject>("Prefabs/Enemy_charger");
        shooter = Resources.Load<GameObject>("Prefabs/Enemy_shooter");
        asteroid = Resources.Load<GameObject>("Prefabs/Asteroid");
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime + Random.Range(0,10); // +1 elke seconde en +1-10 per seconden
        timer2 += Time.deltaTime; // +1 elke seconde
        timer3 += Time.deltaTime;
        if (timer > Random.Range(10, 30) && chargerAmount < 20) // als timer groter is dan 10-30, spawn charger
        {
            SpawnCharger();
            timer = 0;
        }
        if(timer2 > Random.Range(10, 20) && shooterAmount < 20) // als timer groter is dan 10-20, spawn shooter
        {
            SpawnShooter();
            timer2 = 0;
        }
        if (timer3 > 10 && asteroidAmount < 10)
        {
            SpawnAsteroid();
        }

        chargerCount = GameObject.FindGameObjectsWithTag("Enemy");
        chargerAmount = chargerCount.Length;
        shooterCount = GameObject.FindGameObjectsWithTag("ShooterEnemy");
        shooterAmount = shooterCount.Length;
        asteroidCount = GameObject.FindGameObjectsWithTag("Asteroid");
        asteroidAmount = asteroidCount.Length;
    }

    void SpawnCharger()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            Random.Range(topBorder.transform.position.y, botBorder.transform.position.y),
            Random.Range(botBorder.transform.position.z, topBorder.transform.position.z));
       Instantiate(charger, pos, Quaternion.identity);
        if(charger.transform.position.x > cam.transform.position.x)
        {
        }
        if (charger.transform.position.y > cam.transform.position.y)
        {   
        }
    }
    void SpawnShooter()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            0,
            Random.Range(botBorder.transform.position.z, topBorder.transform.position.z));
        Instantiate(shooter, pos, Quaternion.identity);
        if (shooter.transform.position.x > cam.transform.position.x)
        {
            
        }
        if (shooter.transform.position.y > cam.transform.position.y)
        {

        }
    }
    void SpawnAsteroid()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            0,
            Random.Range(botBorder.transform.position.z, topBorder.transform.position.z));
        Instantiate(asteroid, pos, Quaternion.identity);
        if (asteroid.transform.position.x > cam.transform.position.x)
        {
            
        }
        if (asteroid.transform.position.y > cam.transform.position.y)
        {

        }
    }
}