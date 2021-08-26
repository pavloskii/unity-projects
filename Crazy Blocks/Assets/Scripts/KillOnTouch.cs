using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnTouch : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            MovingBlock.Score = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
