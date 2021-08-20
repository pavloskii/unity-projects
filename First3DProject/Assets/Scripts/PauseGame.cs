using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Time.timeScale = 0;
            GamePaused = true;
            Cursor.visible = true;
            _audioSource.Pause();
            PauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            GamePaused = false;
            Cursor.visible = false;
            _audioSource.UnPause();
            PauseMenu.SetActive(false);
        }

    }
}
