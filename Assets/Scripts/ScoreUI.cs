using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;

    private void Start()
    {
        GoalManager.Instance.onScoreChanged += GoalManager_onScoreChanged;
        UpdateVisuals();
    }

    private void GoalManager_onScoreChanged(object sender, System.EventArgs e)
    {
        UpdateVisuals();
    }

    private void UpdateVisuals()
    {
        player1Score.text = GoalManager.Instance.player1Score.ToString();
        player2Score.text = GoalManager.Instance.player2Score.ToString();
    }
}
