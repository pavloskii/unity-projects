using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalTime : MonoBehaviour
{
    public GameObject TimeDisplay;
    public int Seconds = 30;
    public bool DeductingTime = false;
    public GameObject TimeUpText;
    public GameObject FadeOut;
    public GameObject Player;

    void Update()
    {
        if (Seconds == 0)
        {
            Player.GetComponent<PlayerControls>().enabled = false;
            TimeUpText.SetActive(true);
            FadeOut.SetActive(true);
            StartCoroutine(RespawningLevel());
            return;
        }

        if (DeductingTime == false)
        {
            DeductingTime = true;
            StartCoroutine(DeductSecond());
        }
    }

    IEnumerator DeductSecond()
    {
        yield return new WaitForSeconds(1);
        Seconds -= 1;
        TimeDisplay.GetComponent<Text>().text = $"TIME:{Seconds}";
        DeductingTime = false;
    }

    IEnumerator RespawningLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
