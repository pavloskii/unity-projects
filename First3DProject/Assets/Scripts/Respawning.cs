using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawning : MonoBehaviour
{
    void Start()
    {
        GlobalCoins.CointCount = 0;
        SceneManager.LoadScene(GlobalLevel.LevelNumber);
    }
}
