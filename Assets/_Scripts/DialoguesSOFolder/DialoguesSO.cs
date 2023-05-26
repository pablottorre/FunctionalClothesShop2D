using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(menuName = "Dialogues")]
public class DialoguesSO : ScriptableObject
{
    [Header("Text")]
    public string dialogueText;
}
