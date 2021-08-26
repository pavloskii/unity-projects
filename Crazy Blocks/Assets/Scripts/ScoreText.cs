using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    void Update()
    {
        GetComponent<TMP_Text>().SetText(MovingBlock.Score.ToString());
    }
}
