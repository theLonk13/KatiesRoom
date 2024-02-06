using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldInteractable : MonoBehaviour
{
    [SerializeField] UIInteractable linkedObj; // the UI object that this object links to and will open if clicked on

    public int objID = -1; // id of obj

    public void Interact()
    {
        // If the ui interactable linked with this world obj is active, do nothing
        if (!linkedObj.GetHidden()) return;

        if(linkedObj == null)
        {
            //if linkedObj is null, then this obj should directly change dialogue conditions
            UpdateConditions();
        }else{
            //if linkedObj is NOT null, then there is a more detailed version of that object that should pop up (UI Object)
            //use an Animator for this
            linkedObj.ToggleHidden();
        }
    }

    void UpdateConditions()
    {
        //use object ID to figure out what conditions to change
        //TODO Figure out how we want to set up condition changes
    }
}
