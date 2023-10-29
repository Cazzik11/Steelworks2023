using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VignetteFade : MonoBehaviour
{
    public DialogueManager DialogueManager;
    public List<Image> VignetteItems;
    public float FadeTime;
    public float Delay;

    private List<VignetteData> _vignetteDatas;
    private float _timeRemaining;
    private bool _fade;

    private void Awake()
    {
        _vignetteDatas = new List<VignetteData>();

        foreach (var item in VignetteItems)
        {
            var data = new VignetteData();
            data.Image = item;
            data.Opacity = item.color.a;
            _vignetteDatas.Add(data);

            item.color = new Color(item.color.r, item.color.g, item.color.b, 1f);
        }

        DialogueManager.OnDialogueEnded += Fade;
    }

    public void Fade()
    {
        DialogueManager.OnDialogueEnded -= Fade;
        Invoke("FadeDelayed", Delay);
    }

    public void FadeDelayed()
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

        var lerpValue = 1 - _timeRemaining / FadeTime;

        foreach (var data in _vignetteDatas)
        {
            var alphaValue = Mathf.Lerp(1f, data.Opacity, lerpValue);
            data.Image.color = new Color(data.Image.color.r, data.Image.color.g, data.Image.color.b, alphaValue);
        }
    }

    private class VignetteData
    {
        public Image Image;
        public float Opacity;
    }
}
