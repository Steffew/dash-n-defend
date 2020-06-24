using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform playerTarget;
    public float playerSpeed = 20.0f;
    void Start()
    {
        playerTarget = GameObject.Find("Princess").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (StateCheck.isGameOver == false)
        {
            transform.LookAt(playerTarget.position);
            transform.Translate(0.0f, 0.0f, playerSpeed * Time.deltaTime);
        }

        if (transform.position.y > 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Prince")
        {
            CameraShake.shakeDuration = 0.1f;
            DisplayUI.score += 13;
            Destroy(this.gameObject);
        }

        if (collision.gameObject.tag == "Princess" && StateCheck.isGameOver == false)
        {

            CameraShake.shakeDuration = 0.1f;
            Destroy(gameObject);
            StateCheck.isGameOver = true;
        }
    }
    }
