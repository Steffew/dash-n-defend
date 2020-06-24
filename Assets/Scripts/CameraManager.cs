using UnityEngine;
using System.Collections;
 
public class CameraManager : MonoBehaviour {
    public float duration = 1.0f;
    private float elapsed = 0.0f;
    public bool startGame = true;
      
    void Start () {
    }
 
    void Update() {
        if (startGame) {
            elapsed += Time.deltaTime / duration;
            GetComponent<Camera>().orthographicSize = Mathf.Lerp(50, 65, Mathf.SmoothStep(0.0f, 1f, elapsed));
            StartCoroutine(StartGame());
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        startGame = false;
    }
}