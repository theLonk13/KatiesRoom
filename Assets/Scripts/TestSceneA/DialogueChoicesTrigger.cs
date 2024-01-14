using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueChoicesTrigger : MonoBehaviour
{
    public DialogueChoices choices;
    public Text[] choiceText;

    public void Start()
    {
        for(int i = 0; i < choiceText.Length; i++)
        {
            choiceText[i].text = choices.choices[i];
        }
    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartChoices(choices);
    }
}
