using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

// Manages the Dialogue Boxes
public class DialogueManager : MonoBehaviour
{

    public Text nameText; // Name of character's dialogue
    public Text dialogueText; // Text in dialogue box;

    //public Animator animator; // Animator component of dialogue box

    private Queue<string> sentences;

    // Global stats for player
    public int statLikeKatie;
    public int statRealPerson;
    public int statAffection;

    public Text[] choiceText; // Text in choice boxes
    private GameObject connectingDialogue; // The next dialogue that should play
    void Start()
    {
        sentences = new Queue<string>();
        
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        statLikeKatie += dialogue.PointsLikeKatie;
        statRealPerson += dialogue.PointsRealPerson;
        statAffection += dialogue.PointsAffection;

        if (connectingDialogue != null)
        {
            connectingDialogue.SetActive(false);
        }
        connectingDialogue = dialogue.connectingDialogue;


        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("End of conversation");
        //animator.SetBool("IsOpen", false);
        
        if(connectingDialogue != null) //add another part to check if the connecting is choices
        {
            connectingDialogue.SetActive(true);
            StartChoices(connectingDialogue.GetComponent<DialogueChoicesTrigger>().choices);
        }
    }

    public void StartChoices(DialogueChoices choices)
    {
        for (int i = 0; i < choiceText.Length; i++)
        {
            choiceText[i].text = choices.choices[i];
        }
    }

}
