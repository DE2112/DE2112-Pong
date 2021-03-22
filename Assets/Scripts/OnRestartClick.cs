using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnRestartClick : MonoBehaviour
{
    private string _gameScene;
    public void OnRestart()
    {
        _gameScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(_gameScene);
    }
}
