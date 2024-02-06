using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour
{
   /*
    * This script handles whenever the mouse is clicked
    * This is to avoid having every world object check for raycast collision
    */

    // ray and raycastHit objects to track if the mouse clicked on an object
    Ray ray;
    RaycastHit hit;

    //array of gameobjects that are world interactables
    GameObject[] worldObjs;

    // Start is called before the first frame update
    void Start()
    {
        worldObjs = GameObject.FindGameObjectsWithTag("WorldInteractable");
    }

    // Update is called once per frame
    void Update()
    {
        CheckInteractables();
    }

    // Checks all world interactables if they have been clicked on (prioritizes the closest obj to the camera)
    void CheckInteractables()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("clicked");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                foreach (GameObject obj in worldObjs)
                {
                    if (obj.name.Equals(hit.collider.name))
                    {
                        WorldInteractable objScript = obj.GetComponent<WorldInteractable>();
                        if (objScript != null)
                        {
                            objScript.Interact();
                        }
                        continue;
                    }
                }
            }
        }
    }
}
