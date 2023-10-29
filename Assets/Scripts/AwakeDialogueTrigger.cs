using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeDialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    private void Awake()
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}
