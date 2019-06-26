using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDScript : MonoBehaviour
{
    public GameObject Target;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
        Target = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - Target.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Target != null)
        {
            transform.position = Target.transform.position + offset;
        }

    }
}
