using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateCheck : MonoBehaviour
{
    static public bool isGameOver;
    public GameObject goObj;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true)
        {
            goObj.SetActive(true);

            if (Input.anyKey)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
