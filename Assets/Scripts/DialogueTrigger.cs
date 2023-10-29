using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Message[] messages;
    public Actor[] actors;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
    }
}

[System.Serializable]
public class Message {
    public int actorId;
    public string message;
    public AudioClip clip;
}
    
[System.Serializable]
public class Actor {
    public string name;
    public Sprite sprite;
}