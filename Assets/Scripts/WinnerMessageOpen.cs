using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinnerMessageOpen : MonoBehaviour
{
    [Header("Final Stats")]
    public (int, int) score;
    [SerializeField] private int _maxScore;

    [Header("Dependancies")]
    [SerializeField] private GameScore gameScore;
    [SerializeField] private Text aiScore;
    [SerializeField] private Text playerScore;
    [SerializeField] private Text winner;
    private GameObject panel;

    void Update()
    {
        score = gameScore.score;
        aiScore.text = score.Item1.ToString();
        playerScore.text = score.Item2.ToString();
        winner.text = gameScore.winner;
    }
}
