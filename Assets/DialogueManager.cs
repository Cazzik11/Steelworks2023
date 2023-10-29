using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TMP_Text actorName;
    public TMP_Text messageText;
    public RectTransform backgroundBox;
    public Action OnDialogueEnded;
    public Action<int> OnMessageAppear;

    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;
    public static bool isActive = false;
    private AudioSource _audioSource;

    private void Awake()
    {
        CreateSource();
    }

    private void CreateSource()
    {
        if (_audioSource == null)
        {
            var go = new GameObject("Message Audio Source");
            _audioSource = go.AddComponent<AudioSource>();
        }
    }

    public void OpenDialogue(Message[] messages, Actor[] actors) 
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started conversation! Loaded messages: " + messages.Length);
        DisplayMessage();
        backgroundBox.LeanScale(Vector3.one, 0.5f);
    }

    private void DisplayMessage() 
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

        AnimateTextColor();
        PlayMessageSound(messageToDisplay);
        OnMessageAppear?.Invoke(activeMessage);
    }

    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length) 
        {
            DisplayMessage();
        } 
        else 
        {
            OnDialogueEnded?.Invoke();
            Debug.Log("Conversation ended!");
            backgroundBox.LeanScale(Vector3.zero, 0.5f).setEaseInOutExpo();
            isActive = false;
        }
    }

    private void PlayMessageSound(Message message)
    {
        if (message.clip == null)
        {
            return;
        }

        CreateSource();

        if (_audioSource.isPlaying)
        {
            _audioSource.Stop();
        }

        _audioSource.PlayOneShot(message.clip);
    }

    private void AnimateTextColor() 
    {
        LeanTween.textAlpha(messageText.rectTransform, 0, 0);
        LeanTween.textAlpha(messageText.rectTransform, 1, 0.5f);
    }
   
    // Start is called before the first frame update
    void Start()
    {
        backgroundBox.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive == true)
        {
            NextMessage();
        }
    }
}