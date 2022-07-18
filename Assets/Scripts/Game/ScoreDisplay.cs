using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshPro))]
public class ScoreDisplay : MonoBehaviour
{
    TextMeshPro text;
    void Start()
    {
        text = GetComponent<TextMeshPro>();
        DisplayScore();
    }

    private void DisplayScore()
    {
        text.text = PlayerScore.Score.ToString();
    }
    private void OnEnable()
    {
        PlayerScore.OnScoreUpdated += DisplayScore;
    }
    private void OnDisable()
    {
        PlayerScore.OnScoreUpdated -= DisplayScore;
    }
}
