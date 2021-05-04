using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class UiGameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private TextMeshProUGUI _shieldText;
    [SerializeField] private TextMeshProUGUI _planetText;
    [SerializeField] private TextMeshProUGUI _gameScore;

    private bool _moveLeft = false;
    private bool _moveRight = false;

    void Start()
    {
        Planet.OnDamaged += ChangedPlanetState;
        GameManager.OnSetScore += ChangedScore;
    }

    public static event Action<int> OnMovingButton;
    public static event Action<bool> OnSoundToggle;
    public static event Action<bool> OnMusicToggle;
    public static event Action<float> OnSoundChange;
    public static event Action<float> OnMusicChange;

    private void ChangedPlanetState(int shieldHp, int planetHp)
    {
        _shieldText.text = "SHIELD  HP:  " + shieldHp;
        _planetText.text = "PLANET HP:  " + planetHp;

        if(planetHp <= 0)
        {
            GameOver();
        }
    }

    private void ChangedScore(int score)
    {
        _gameScore.text = score.ToString();
    }

    public void SoundToggle(Toggle toggle)
    {
        OnSoundToggle?.Invoke(toggle.isOn);
    }

    public void MusicToggle(Toggle toggle)
    {
        
        OnMusicToggle?.Invoke(toggle.isOn);
    }

    public void SoundChange(Slider slider)
    {
        OnSoundChange?.Invoke(slider.value);
    }

    public void MusicChange(Slider slider)
    {
        OnMusicChange?.Invoke(slider.value);
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

    private void OnDestroy()
    {
        Planet.OnDamaged -= ChangedPlanetState;
        GameManager.OnSetScore -= ChangedScore;
    }
}
