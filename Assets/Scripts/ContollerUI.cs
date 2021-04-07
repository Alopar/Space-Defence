using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class ContollerUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private TextMeshProUGUI _shieldText;
    [SerializeField] private TextMeshProUGUI _planetText;
    [SerializeField] private Toggle _soundToggle;
    [SerializeField] private Sprite _soundToggleSpriteOn;
    [SerializeField] private Sprite _soundToggleSpriteOff;
    [SerializeField] private Toggle _musicToggle;
    [SerializeField] private Sprite _musicToggleSpriteOn;
    [SerializeField] private Sprite _musicToggleSpriteOff;

    private bool _moveLeft = false;
    private bool _moveRight = false;

    void Start()
    {
        Planet.OnDamaged += ChangedPlanetState;
    }

    public static event Action<int> OnMovingButton;

    private void ChangedPlanetState(int shieldHp, int planetHp)
    {
        _shieldText.text = "SHIELD  HP:  " + shieldHp;
        _planetText.text = "PLANET HP:  " + planetHp;

        if(planetHp <= 0)
        {
            GameOver();
        }
    }

    public void SoundToggle()
    {   
        Image image = _soundToggle.GetComponent<Image>();
        if (_soundToggle.isOn)
        {   
            image.sprite = _soundToggleSpriteOn;
        }
        else
        {            
            image.sprite = _soundToggleSpriteOff;
        }
    }

    public void MusicToggle()
    {
        Image image = _musicToggle.GetComponent<Image>();
        if (_musicToggle.isOn)
        {
            image.sprite = _musicToggleSpriteOn;
        }
        else
        {
            image.sprite = _musicToggleSpriteOff;
        }
    }

    public void ToHome()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        _gameOver.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }

    public void RepeatScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Game");
    }

    public void PlatformMovingLeftDown()
    {
        _moveLeft = true;
    }

    public void PlatformMovingLeftUp()
    {
        _moveLeft = false;
    }

    public void PlatformMovingRightDown()
    {
        _moveRight = true;
    }

    public void PlatformMovingRightUp()
    {
        _moveRight = false;
    }

    private void Update()
    {
        if (_moveLeft)
        {
            OnMovingButton?.Invoke(1);
        }

        if (_moveRight)
        {
            OnMovingButton?.Invoke(-1);
        }
    }
}
