using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool _isPaused;
    private void Awake()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            _isPaused = !_isPaused;
        }
    }

    private void Pause()
    {
        if (_isPaused)
        {
            Time.timeScale = 1;
        } else
        {
            Time.timeScale = 0;
        }
    }
}
