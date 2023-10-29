using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBinder : MonoBehaviour
{
    public DialogueManager DialogueManager;
    public FadeOut FadeOut;
    public FadeOut FadeIn;

    private void Awake()
    {
        DialogueManager.OnDialogueEnded += FadeOutCharacter;
        DialogueManager.OnMessageAppear += FadeInCharacter;
    }

    private void FadeInCharacter(int index)
    {
        if (index == 1)
        {
            DialogueManager.OnMessageAppear -= FadeInCharacter;
            FadeIn.Fade();
        }

    }

    private void FadeOutCharacter()
    {
        DialogueManager.OnDialogueEnded -= FadeOutCharacter;
        FadeOut.Fade();
    }
}
