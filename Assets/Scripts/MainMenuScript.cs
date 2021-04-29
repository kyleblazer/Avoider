using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void StartGame(string SceneName)
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LeaveToMenu(string SceneName)
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitApplication()
    {
        Application.Quit();
        Debug.Log("Application quit");
    }
}