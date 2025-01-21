using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public static GoalManager Instance { get; private set; }
    public event EventHandler onScoreChanged;

    private const string LEFT_GOAL = "LeftGoal";
    private const string RIGHT_GOAL = "RightGoal";

    private int pointsToEndGame = 12;
    public int player1Score = 0;
    public int player2Score = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Ball.Instance.onGoalScored += Ball_onGoalScored;
    }

    private void Ball_onGoalScored(object sender, Ball.onGoalScoredEventArgs e)
    {
        if (e.collider.gameObject.name == LEFT_GOAL)
        {
            AddPointPlayer1();
        }
        else if (e.collider.gameObject.name == RIGHT_GOAL)
        {
            AddPointPlayer2();
        }
        onScoreChanged?.Invoke(this, EventArgs.Empty);

        if (player1Score >= pointsToEndGame || player2Score >= pointsToEndGame)
        {
            ResetGame();
        }
    }

    private void AddPointPlayer1()
    {
        player1Score++;
    }

    private void AddPointPlayer2()
    {
        player2Score++;
    }

    private void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
    }
}
