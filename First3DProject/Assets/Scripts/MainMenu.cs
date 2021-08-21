using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int LoadLevel;
    public GameObject HintBox;
    public int hintNum;

    private void Start()
    {
        hintNum = Random.Range(1, 4);
        if (hintNum == 1)
        {
            HintBox.GetComponent<Text>().text = "Collect 5 coins to complete the level";
        }
        if (hintNum == 2)
        {
            HintBox.GetComponent<Text>().text = "Don't let the timer hit zero";
        }
        if (hintNum == 3)
        {
            HintBox.GetComponent<Text>().text = "Don't crash into the obstacles";
        }
    }

    public void StartGame()
    {
        GlobalLevel.LevelNumber = 3;
        SceneManager.LoadScene(GlobalLevel.LevelNumber);
    }

    public void LoadGame()
    {
        LoadLevel = PlayerPrefs.GetInt("LevelLoadNum");

        if (LoadLevel < 3)
        {
            SceneManager.LoadScene(GlobalLevel.LevelNumber);
        }
        else
        {
            GlobalLevel.LevelNumber = LoadLevel;
            SceneManager.LoadScene(LoadLevel);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
