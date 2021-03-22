using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private BallController ballController;
    [SerializeField] private GameScore gameScore;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.BackQuote)) 
        {
            Restart();
        }
    }

    public void Restart()
    {
        StartCoroutine(ballController.InitCoroutine(3f));
        gameScore.score = (0, 0);
    }
}
