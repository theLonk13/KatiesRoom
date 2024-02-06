using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractable : MonoBehaviour
{
    public int id = 0;
    [SerializeField] UIInteractable linkedObj; // another UI object that this one links to, if another one will be opened when clicking on this one

    [SerializeField] Animator thisAnim; // The animator controller this interactable's presence on the screen
    bool hidden = true; // current state of the interactable

    /*
     * Toggles the state of this interactable between being shown on screen, or hidden off screen
     */
    public void ToggleHidden()
    {
        hidden = !hidden;
        thisAnim.SetBool("HideInteractable", hidden);
    }

    /*
     * Interact is called when player clicks on the main image of this interactable
     * Either opens another interactable if the field is filled, or triggers this objects dialogue/condition changes if this is an object
     */
    public void Interact()
    {
        if(linkedObj != null)
        {
            linkedObj.ToggleHidden();
        }
        else
        {
            test_ObjInteract();
        }
    }

    public bool GetHidden()
    {
        return hidden;
    }

    //placeholder interact
    public void test_ObjInteract()
    {
        Debug.Log($"Object of id {id} interacted with");
    }
}
