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
        timer += Time.deltaTime;
        if (timer > 10)
        {
            SpawnCharger();
            SpawnShooter();
            timer = 0;
        }
    }

    void SpawnCharger()
    {
        Vector3 pos = new Vector3(
            Random.Range(leftBorder.transform.position.x, rightBorder.transform.position.x),
            0,
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