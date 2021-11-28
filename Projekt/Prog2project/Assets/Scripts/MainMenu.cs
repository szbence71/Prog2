using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        PlayerPrefs.SetInt("ScoreValue", ScoreScript.scoreValue / 1000);
        PlayerPrefs.Save();
        Application.Quit();
    }
}