using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerSlider : MonoBehaviour
{
    [SerializeField] private SettingName _settingName;

    private Slider _slider;

    void Start()
    {
        _slider = GetComponent<Slider>();

        switch (_settingName)
        {
            case SettingName.SoundVolume:
                _slider.value = StorageSettings.soundVolume;
                break;
            case SettingName.MusicVolume:
                _slider.value = StorageSettings.musicVolume;
                break;
        }
    }
}
