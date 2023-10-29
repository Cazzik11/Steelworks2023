using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsSound : MonoBehaviour
{
    public AudioClip[] Clips;
    public float MinInterval;
    public float MaxInterval;
    public InputController InputController;
    public float Volume;

    private List<AudioSource> _sources = new List<AudioSource>();
    private float _lockTime;
    private int _lastRandomIndex = -1;
    private int _lastSourceIndex;

    private void Awake()
    {
        CreateNewSourceObject();
        CreateNewSourceObject();
        CreateNewSourceObject();
    }

    private void Update()
    {
        if (_lockTime > 0)
        {
            _lockTime -= Time.deltaTime;
        }

        if (InputController.IsMoving() && _lockTime <= 0)
        {
            _lockTime = Random.Range(MinInterval, MaxInterval);
            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        var source = GetFreeAudioSource();
        var randomClipIndex = Random.Range(0, Clips.Length - 1);
        if (randomClipIndex >= _lastRandomIndex)
        {
            randomClipIndex++;
        }

        var clip = Clips[randomClipIndex];
        source.PlayOneShot(clip, Volume);
        _lastRandomIndex = randomClipIndex;
    }

    private AudioSource GetFreeAudioSource()
    {
        _lastSourceIndex = (_lastSourceIndex + 1) % _sources.Count;
        return _sources[_lastSourceIndex];
    }

    private AudioSource CreateNewSourceObject()
    {
        var go = new GameObject("AudioSource");
        var newSource = go.AddComponent<AudioSource>();
        _sources.Add(newSource);
        return newSource;
    }
}
