using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageSettings : MonoBehaviour
{
    public static bool musicOn { get; private set; }    
    public static bool soundOn { get; private set; }
    public static float musicVolume { get; private set; }
    public static float soundVolume { get; private set; }

    void Start()
    {
        musicOn = PlayerPrefs.HasKey("music_on") ? Convert.ToBoolean(PlayerPrefs.GetInt("music_on")) : true;
        soundOn = PlayerPrefs.HasKey("sound_on") ? Convert.ToBoolean(PlayerPrefs.GetInt("sound_on")) : true;

        musicVolume = PlayerPrefs.HasKey("music_volume") ? Mathf.Clamp(PlayerPrefs.GetFloat("music_volume"), 0, 100) : 50;
        soundVolume = PlayerPrefs.HasKey("sound_volume") ? Mathf.Clamp(PlayerPrefs.GetFloat("sound_volume"), 0, 100) : 50;

        ControllerUI.OnMusicToggle += SetMusicOn;
        ControllerUI.OnSoundToggle += SetSoundOn;
        ControllerUI.OnMusicChange += SetMusicVolume;
        ControllerUI.OnSoundChange += SetSoundVolume;
    }

    private void SetMusicOn(bool value)
    {
        musicOn = value;
        PlayerPrefs.SetInt("music_on", Convert.ToInt32(value));
    }

    private void SetSoundOn(bool value)
    {
        soundOn = value;
        PlayerPrefs.SetInt("sound_on", Convert.ToInt32(value));
    }

    private void SetMusicVolume(float value)
    {
        musicVolume = value;
        PlayerPrefs.SetFloat("music_volume", value);
    }

    private void SetSoundVolume(float value)
    {
        soundVolume = value;
        PlayerPrefs.SetFloat("sound_volume", value);
    }

    private void OnDestroy()
    {
        ControllerUI.OnMusicToggle -= SetMusicOn;
        ControllerUI.OnSoundToggle -= SetSoundOn;
        ControllerUI.OnMusicChange -= SetMusicVolume;
        ControllerUI.OnSoundChange -= SetSoundVolume;
    }
}

public enum SettingName
{
    MusicOn,
    SoundOn,
    SoundVolume,
    MusicVolume
}