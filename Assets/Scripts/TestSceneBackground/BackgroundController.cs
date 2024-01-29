using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script used to controll background. Could probably be eventually combined with GameManager
public class BackgroundController : MonoBehaviour
{
    [SerializeField] private float moveRightSensativity; //past a certain % of screen to have mouse move right
    [SerializeField] private float moveLeftSensativity; //before a certain % of screen to have mouse move left
    public GameObject cam;
    [SerializeField] private float cameraSpeed;
    
    // for testing ease in movement
    //[SerializeField] private float cameraSpeed2;
    //private float time;

    //Controls for camera
    [SerializeField] private KeyCode moveRight;
    [SerializeField] private KeyCode moveLeft;
    [SerializeField] private KeyCode resetCamera;

    [SerializeField] public Vector3 cameraDefaultPos;

    void Start()
    {
        
    }

    void Update()
    {
        // for testing
        //time += Time.deltaTime;
        //float progress = time/cameraSpeed2;

        if(Input.mousePosition.x > Screen.width * moveRightSensativity || Input.GetKey(moveRight))
        {
            cam.transform.position = cam.transform.position + new Vector3(cameraSpeed, 0, 0);

            // Testing to see if it's possible to have the camera movement ease in
            //Vector3.Lerp(start, end, progress);
            //Vector3 startPos = cam.transform.position;
            //Vector3 endPos = Input.mousePosition;
            //cam.transform.position = Vector3.Lerp(startPos, endPos, progress);
            
        }
        if (Input.mousePosition.x < Screen.width * moveLeftSensativity || Input.GetKey(moveLeft))
        {
            cam.transform.position = cam.transform.position + new Vector3(-cameraSpeed, 0, 0);
        }
        if(Input.GetKeyDown(resetCamera))
        {
            cam.transform.position = cameraDefaultPos; // Might need to change default position depending on changes
        }
        
    }
}
