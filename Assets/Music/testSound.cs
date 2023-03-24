using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class testSound
{
    public string name;
    public AudioClip clip;

    [Range(0, 10f)]
    public float volume;

    [Range(0, 10f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;

    public bool loop;
    public bool playOnAwake;
}
