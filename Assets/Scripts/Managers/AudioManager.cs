using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _self;

    private bool _soundOn = true;
    private bool _musicOn = true;

    private float _soundVolume = 100;
    private float _musicVolume = 100;

    public Sound[] sounds;    

    void Awake()
    {
        if(_self == null)
        {
            _self = this;
        }
        else
        {
            Destroy(this);
        }

        foreach (Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }
    }

    void Start()
    {
        _soundOn = StorageSettings.soundOn;
        _musicOn = StorageSettings.musicOn;
        _soundVolume = StorageSettings.soundVolume;
        _musicVolume = StorageSettings.musicVolume;

        ChangeVolume(SoundType.Sound);
        ChangeVolume(SoundType.Music);

        UiGameManager.OnSoundToggle += ChangeSoundOn;
        UiGameManager.OnMusicToggle += ChangeMusicOn;
        UiGameManager.OnSoundChange += ChangeSoundVolume;
        UiGameManager.OnMusicChange += ChangeMusicVolume;
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

    public static void Play(string name)
    {
        Sound sound = Array.Find(_self.sounds, sound => sound.name == name);

        if(sound == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        switch (sound.soundType)
        {
            case SoundType.Sound:
                sound.source.Play();
                sound.source.mute = !_self._soundOn;
                break;
            case SoundType.Music:
                sound.source.Play();
                sound.source.mute = !_self._musicOn;
                break;
        }
    }

    private void OnDestroy()
    {
        UiGameManager.OnSoundToggle -= ChangeSoundOn;
        UiGameManager.OnMusicToggle -= ChangeMusicOn;
        UiGameManager.OnSoundChange -= ChangeSoundVolume;
        UiGameManager.OnMusicChange -= ChangeMusicVolume;
    }
}