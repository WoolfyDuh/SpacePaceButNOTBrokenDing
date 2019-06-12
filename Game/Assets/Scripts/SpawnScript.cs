using System.Collections;
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
    private GameObject border;
    private float timer = 0;
    private float timer2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        border = GameObject.Find("Bovengrens");
        topBorder = border.transform;
        border = GameObject.Find("Rechtergrens");
        rightBorder = border.transform;
        border = GameObject.Find("Ondergrens");
        botBorder = border.transform;
        border = GameObject.Find("Linkergrens");
        leftBorder = border.transform;
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime + Random.Range(0,10);
        timer2 += Time.deltaTime;
        if (timer > Random.Range(10, 30))
        {
            SpawnCharger();
            timer = 0;
        }
        if(timer2 > Random.Range(10, 20))
        {
            SpawnShooter();
            timer2 = 0;
        }
    }

    void SpawnCharger()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            Random.Range(topBorder.transform.position.y, botBorder.transform.position.y),
            Random.Range(botBorder.transform.position.z, topBorder.transform.position.z));
       Instantiate(charger, pos, Quaternion.identity);
    }
    void SpawnShooter()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            0,
            Random.Range(botBorder.transform.position.z, topBorder.transform.position.z));
        Instantiate(shooter, pos, Quaternion.identity);
    }
}