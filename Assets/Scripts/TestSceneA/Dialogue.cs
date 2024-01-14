using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name; // Name of character
    [TextArea(3, 10)]
    public string[] sentences; // The dialogue

    public int PointsLikeKatie;
    public int PointsRealPerson;
    public int PointsAffection;

    public GameObject connectingDialogue; // dialogue for choices
}
