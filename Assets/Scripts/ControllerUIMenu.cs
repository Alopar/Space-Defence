using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerUIMenu : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("BackgroundMainMenu");
    }

    public void StartGame()
    {   
        SceneManager.LoadScene("Game");        
    }
}