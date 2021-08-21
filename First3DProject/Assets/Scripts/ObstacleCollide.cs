using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollide : MonoBehaviour
{
    public GameObject HurtText;
    public GameObject FadeOut;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player.GetComponent<PlayerControls>().enabled = false;
            HurtText.SetActive(true);
            FadeOut.SetActive(true);
            StartCoroutine(RespawningLevel());
            return;
        }
    }
    IEnumerator RespawningLevel()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(2);
    }
}
