using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public int ImportedCoins;
    public GameObject CompletedText;
    public GameObject FadeOut;
    public GameObject Player;

    void Update()
    {
        ImportedCoins = GlobalCoins.CointCount;
        if (ImportedCoins == 5)
        {
            StartCoroutine(LevelCompleted());
        }
    }

    IEnumerator LevelCompleted()
    {
        yield return new WaitForSeconds(0.5f);

        Player.GetComponent<PlayerControls>().enabled = false;
        CompletedText.SetActive(true);
        FadeOut.SetActive(true);

        yield return new WaitForSeconds(3);

        if (IsLastLevel())
        {
            GlobalLevel.LevelNumber = 3;
        }
        else
        {
            GlobalLevel.LevelNumber += 1;
        }

        PlayerPrefs.SetInt("LevelLoadNum", GlobalLevel.LevelNumber);
        SceneManager.LoadScene(2);
    }

    private bool IsLastLevel() => GlobalLevel.LevelNumber == SceneManager.sceneCountInBuildSettings - 1;
}
