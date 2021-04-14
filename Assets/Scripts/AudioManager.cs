using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private bool _soundOn = true;
    [SerializeField] private bool _musicOn = true;

    [SerializeField, Range(0f, 1f)] private float _soundVolume;
    [SerializeField, Range(0f, 1f)] private float _musicVolume;

    public Sound[] sounds;
    public static AudioManager instance;

    void Awake()
    {
        instance = this;

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }

    private void Start()
    {
        _soundOn = StorageSettings.soundOn;
        _musicOn = StorageSettings.musicOn;
        _soundVolume = StorageSettings.soundVolume;
        _musicVolume = StorageSettings.musicVolume;

        ChangeVolume(SoundType.Sound);
        ChangeVolume(SoundType.Music);

        ControllerUI.OnSoundToggle += ChangeSoundOn;
        ControllerUI.OnMusicToggle += ChangeMusicOn;
        ControllerUI.OnSoundChange += ChangeSoundVolume;
        ControllerUI.OnMusicChange += ChangeMusicVolume;
    }

    private void ChangeSoundOn(bool value)
    {
        _soundOn = value;
        ChangeMute(SoundType.Sound, _soundOn);
    }

    private void ChangeMusicOn(bool value)
    {
        _musicOn = value;
        ChangeMute(SoundType.Music, _musicOn);
    }

    private void ChangeSoundVolume(float value)
    {
        _soundVolume = value;
        ChangeVolume(SoundType.Sound);
    }

    private void ChangeMusicVolume(float value)
    {
        _musicVolume = value;
        ChangeVolume(SoundType.Music);
    }

    private void ChangeVolume(SoundType soundType)
    {
        Sound[] _sounds = Array.FindAll(sounds, sound => sound.soundType == soundType);
        foreach(Sound _sound in _sounds)
        {
            switch (_sound.soundType)
            {
                case SoundType.Sound:
                    _sound.source.volume = _sound.volume * _soundVolume;
                    break;
                case SoundType.Music:
                    _sound.source.volume = _sound.volume * _musicVolume;                    
                    break;
            }
        }
    }

    private void ChangeMute(SoundType soundType, bool mute)
    {
        Sound[] _sounds = Array.FindAll(sounds, sound => sound.soundType == soundType);
        foreach (Sound sound in _sounds)
        {
            sound.source.mute = !mute;
        }
    }

    public void Play(string name) 
    {
        Sound sound = Array.Find(instance.sounds, sound => sound.name == name);

        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        switch (sound.soundType)
        {
            case SoundType.Sound:
                sound.source.Play();
                sound.source.mute = !_soundOn;
                break;
            case SoundType.Music:
                sound.source.Play();
                sound.source.mute = !_musicOn;
                break;
        }
    }

    private void OnDestroy()
    {
        ControllerUI.OnSoundToggle -= ChangeSoundOn;
        ControllerUI.OnMusicToggle -= ChangeMusicOn;
        ControllerUI.OnSoundChange -= ChangeSoundVolume;
        ControllerUI.OnMusicChange -= ChangeMusicVolume;
    }
}