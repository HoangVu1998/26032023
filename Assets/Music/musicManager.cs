using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour
{
    public Sound[] musicSound;
    public Sound[] SFXsound;
    public Sound[] SFXsoundButon;

    public AudioSource musicSource;

    public AudioSource SFXButonsource;
    public AudioSource SFXSourceNuocchay;
    public AudioSource SFXSourceHeavy;
    public AudioSource DrinkSipAndSwallow;

    public static musicManager instance;
    public bool isPlayingSFX = false;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        PlayMusic("Theme");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSound, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found " + name);
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXsound, x => x.name == name);

        if (s == null)
        {
            Debug.LogError($"Sound not found: {name}");
            return;
        }

        if (isPlayingSFX)
        {
            return;
        }
        if (s.name == "NuocThuong")
        {

        }
        
        isPlayingSFX = true;
        StartCoroutine(WaitForSFXToFinish(s.clip.length));
    }

    private IEnumerator WaitForSFXToFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        isPlayingSFX = false;
    }

    public void PlaySFXbuton(string name)
    {
        Sound s = Array.Find(SFXsoundButon, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found " + name);
        }
        else
        {
            SFXButonsource.clip = s.clip;
            SFXButonsource.Play();
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFXc()
    {
        SFXButonsource.mute = !SFXButonsource.mute;
        SFXSourceNuocchay.mute = !SFXSourceNuocchay.mute;
        SFXSourceHeavy.mute = !SFXSourceHeavy.mute;
        DrinkSipAndSwallow.mute = !DrinkSipAndSwallow.mute;
    }
}
