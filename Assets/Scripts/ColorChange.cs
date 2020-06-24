using UnityEngine;
using System.Collections;
 
[RequireComponent(typeof(SpriteRenderer))]
 public class ColorChange : MonoBehaviour
 {
     private Camera mainCamera;
     public float colorChangeTime = 0.1f;
     private float timeSinceColorChange;
     

     private void Awake()
     {
         mainCamera = GetComponent<Camera>();
     }
     
     void Start()
     {
         mainCamera.backgroundColor = Color.white;
     }
     
     private void Update()
     {
         timeSinceColorChange += Time.deltaTime;
         
         if (mainCamera != null && timeSinceColorChange >= colorChangeTime)
         {
             Color newColor = new Color(
                 Random.value,
                 Random.value,
                 Random.value
                 );

             mainCamera.backgroundColor = newColor;
             timeSinceColorChange = 0f;
         }
     }
 }
