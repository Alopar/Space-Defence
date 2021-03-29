using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContollerUI : MonoBehaviour
{
    private Platform _platform;
    
    private bool _moveLeft = false;
    private bool _moveRight = false;

    void Start()
    {
        _platform = FindObjectOfType<Platform>();
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
            _platform.Moving(1);
        }

        if (_moveRight)
        {
            _platform.Moving(-1);
        }
    }
}
