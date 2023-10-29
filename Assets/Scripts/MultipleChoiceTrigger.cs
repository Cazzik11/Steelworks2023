using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleChoiceTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartDialogue();
    }

    public void StartDialogue()
    {
        FindObjectOfType<MultipleChoice>().Activate();
    }
}
