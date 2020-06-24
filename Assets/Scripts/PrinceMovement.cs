using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinceMovement : MonoBehaviour
{
    private float princeAngle = 0f;
    private float princeRadius = 45f;
    private float targetRadius = 0f;
    public float princeSpeed = 1f;
    public float princeFlySpeed = 1f; 
    private bool shooting;
    private int chargeAmount;
    private int evenCompensation;

    private void Start()
    {
        GetComponent<TrailRenderer>().time = 0f;
        shooting = false;
        chargeAmount = 0;
        evenCompensation = 0;
    }

    void Update()
    {   
        if (StateCheck.isGameOver == false) {
            float x = Mathf.Cos(princeAngle) * princeRadius;
            float z = Mathf.Sin(princeAngle) * princeRadius;
            transform.position = new Vector3(x, transform.position.y, z);
            //Debug.Log(princeAngle);
        }
        
        if (Input.GetButtonDown("PrinceCharge") && !shooting)
        {
            //transform.eulerAngles = new Vector3(0, -princeAngle*57.3f, 0);
            shooting = true;
            targetRadius = -princeRadius;
        }

        if (!shooting && !StateCheck.isGameOver)
        {
            float movement = Input.GetAxis("HorizontalPrince");
            princeAngle += movement * princeSpeed * Time.deltaTime;
            
            if (movement > 0) transform.eulerAngles = new Vector3(0, -princeAngle * 57.3f + evenCompensation, 0);
            if (movement < 0) transform.eulerAngles = new Vector3(0, -princeAngle * 57.3f + 180 + evenCompensation, 0);

        }
        else
        {
            if (!StateCheck.isGameOver)
            {
                GetComponent<TrailRenderer>().time = Mathf.Lerp(0.05f, 10, 5 * Time.deltaTime);
                //transform.eulerAngles += new Vector3(0, 90, 0);
                princeRadius = Mathf.Lerp(princeRadius, targetRadius, princeFlySpeed * Time.deltaTime);
                transform.LookAt(new Vector3(Mathf.Cos(princeAngle) * princeRadius, transform.position.y, Mathf.Sin(princeAngle) * princeRadius));
            }
            if (Mathf.Abs(targetRadius - princeRadius) < 0.2 && !StateCheck.isGameOver)
            {
                chargeAmount ++;
                princeRadius = targetRadius;
                GetComponent<TrailRenderer>().time = 0;
                shooting = false;
                if (chargeAmount % 2 != 0)
                {
                    evenCompensation = -180;
                }
                else
                    evenCompensation = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Princess")
        {
            CameraShake.shakeDuration = 0.2f;
            StateCheck.isGameOver = true;
        }
    }
}
