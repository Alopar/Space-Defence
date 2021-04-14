using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    public bool loop;
    public SoundType soundType;
    [Range(0f, 1f)] public float volume;
    [HideInInspector] public AudioSource source;
}

public enum SoundType
{
    Sound,
    Music
}