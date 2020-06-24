using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    void Update()
    {
        transform.position = gameObject.transform.position;
        transform.LookAt(transform.position + gameObject.GetComponent<Rigidbody>().velocity);
    }
}
