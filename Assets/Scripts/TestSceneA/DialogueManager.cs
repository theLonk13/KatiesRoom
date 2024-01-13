using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    //public Animator animator;

    private Queue<string> sentences;

    private string[] optionsText;
    [SerializeField] private GameObject[] optionButtons;
    public Text[] optionButtonsText;
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        //animator.SetBool("IsOpen", true);
        optionsText = dialogue.options;

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
        if (optionsText != null)
        {
            ShowChoices();
        }
    }
    void ShowChoices()
    {
        Debug.Log(optionsText[0]);
        //Have code to have buttons show (also hide buttons)
        for(int i = 0; i < optionButtonsText.Length; i++)
        {
            optionButtonsText[i].text = optionsText[i];
        }
    }

    void Option1()
    {

    }

    void Option2()
    {

    }

    void Option3()
    {

    }
}
