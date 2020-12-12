using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    private static SceneManage _Instance { get; set; }

    private void Awake()
    {
        if (_Instance != null && _Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _Instance = this;
        }
       // DontDestroyOnLoad(gameObject);
    }
    

    public void LoadGame()
    {
        SceneManager.LoadScene("SceneRPG");
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        //Just work when its an exe
        Application.Quit();
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinScene");
    }

}
