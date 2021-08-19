using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalCoins : MonoBehaviour
{
    public GameObject TextScore;
    public static int CointCount;

    void Update()
    {
        TextScore.GetComponent<Text>().text = $"SCORE:{CointCount}";
    }
}
