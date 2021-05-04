using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerToggle : MonoBehaviour
{   
    [SerializeField] private Sprite _toggleSpriteOn;
    [SerializeField] private Sprite _toggleSpriteOff;
    [SerializeField] private SettingName _settingName;

    private Image _image;
    private Toggle _toggle;
        
    void Start()
    {
        _image = GetComponent<Image>();
        _toggle = GetComponent<Toggle>();

        switch (_settingName)
        {
            case SettingName.MusicOn:
                _toggle.isOn = StorageSettings.musicOn;
                break;
            case SettingName.SoundOn:
                _toggle.isOn = StorageSettings.soundOn;
                break;
        }
    }

    public void ToggleChange()
    {
        if (_toggle.isOn)
        {
            _image.sprite = _toggleSpriteOn;
        }
        else
        {
            _image.sprite = _toggleSpriteOff;
        }
    }
}