using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    [TextArea(3, 10)]
    public string[] sentences;

    public string[] options; //later somehow add more variables to hold 3 variables int LikeKatie, RealPerson, Affection

    public GameObject[] connectingDialogue; //dialogue for options
}
