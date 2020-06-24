using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrincessMovement : MonoBehaviour
{
    public float princessSpeed = 500.0f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!StateCheck.isGameOver)
        {
            float h = Input.GetAxis("HorizontalPrincess") * princessSpeed * Time.deltaTime;
            float v = Input.GetAxis("VerticalPrincess") * princessSpeed * Time.deltaTime;

            rb.velocity = new Vector3(-h, rb.velocity.y, v);
        }
    }
}
