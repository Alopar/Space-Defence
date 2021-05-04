using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiMenuManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Play("BackgroundMainMenu");
    }

    public void StartGame()
    {   
        SceneManager.LoadScene("Game");        
    }
}