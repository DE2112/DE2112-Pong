using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    [Header("Game Stats")]
    public (int, int) score;
    public string winner;
    [SerializeField] [Range(2, 100)] private int _maxScore;

    [Header("Ball Controller")]
    [SerializeField] private BallController ballController;

    [Header("Dependancies")]
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private Text aiScore;
    [SerializeField] private Text playerScore;

    private void Awake()
    {
        winner = "";
        _maxScore = 2;
        winnerPanel.SetActive(false);
    }

    void Update()
    {
        aiScore.text = score.Item1.ToString();
        playerScore.text = score.Item2.ToString();

        if (_maxScore == score.Item1)
        {
            winner = "Winner\nAI";
            winnerPanel.SetActive(true);
            StartCoroutine(ballController.InitCoroutine(1000f));
        }
        else if (_maxScore == score.Item2)
        {
            winner = "Winner\nPlayer";
            winnerPanel.SetActive(true);
            StartCoroutine(ballController.InitCoroutine(1000f));
        }
    }
}
