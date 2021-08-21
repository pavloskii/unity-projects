using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    public bool GamePaused = false;
    public GameObject PauseMenu;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!Input.GetButtonDown("Cancel")) return;

        if (!GamePaused)
        {
            Pause();
        }
        else
        {
            Unpause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GamePaused = true;
        Cursor.visible = true;
        _audioSource.Pause();
        PauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        GamePaused = false;
        Cursor.visible = false;
        _audioSource.UnPause();
        PauseMenu.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(GlobalLevel.LevelNumber);
    }

    public void QuitLevel()
    {
        Time.timeScale = 1;
        GlobalLevel.LevelNumber = 3;
        SceneManager.LoadScene(1);
    }
}
