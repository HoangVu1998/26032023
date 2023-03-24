using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TestMusic : MonoBehaviour
{
    private static TestMusic _instance;
    public static TestMusic Instance => _instance;
    public testSound[] sounds;
    public bool isPlaying = false;
    public string NameStop;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        GetAudio();
    }
    private void Start()
    {
        isPlaying = false;
        Play("Theme");
    }
    private void GetAudio()
    {
        foreach (testSound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
    }
    public void Play(string _name)
    {
        foreach (var s in sounds)
            if (s.name == _name)
                s.source.Play();
    }
    public void playUpdate(string _name)
    {
        foreach (var s in sounds)
        {
            if (s.name == _name)
            {
                if (isPlaying)
                {
                    return;
                }
                s.source.Play();
                isPlaying = true;
                StartCoroutine(WaitForSFXToFinish(s.clip.length));
            }
        }
    }
    private IEnumerator WaitForSFXToFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        isPlaying = false;
    }
    public void StopMusic()
    {
        foreach (var s in sounds)
        {
            if (s.name == "Theme")
            {
                s.source.mute = !s.source.mute;
            }
        }
    }
    public void StopEFC()
    {
        foreach (var s in sounds)
        {
            if (s.name != "Theme")
            {
                s.source.mute = !s.source.mute;
            }
        }
    }
    public void stop(string _name)
    {
        foreach (var s in sounds)
        {
            if (s.name == _name)
            {
                s.source.Stop();
            }
        }
    }
}