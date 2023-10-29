using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public DialogueManager DialogueManager;
    public Image Image;
    public float FadeTime;
    public bool FadeIn;

    private float _timeRemaining;
    private bool _fade;

    public void Fade()
    {
        _fade = true;
        _timeRemaining = FadeTime;
    }

    public void Update()
    {
        if (!_fade)
        {
            return;
        }

        _timeRemaining -= Time.deltaTime;

        if (_timeRemaining <= 0f)
        {
            _fade = false;
        }

        var lerpValue = FadeIn ? _timeRemaining / FadeTime : 1 - _timeRemaining / FadeTime;

        var alphaValue = Mathf.Lerp(1f, 0f, lerpValue);
        Image.color = new Color(Image.color.r,Image.color.g, Image.color.b, alphaValue);
    }
}
