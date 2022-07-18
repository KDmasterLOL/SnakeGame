using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScore : Initialise
{
    private static int s_score;
    public static int Score
    {
        get => s_score;
        private set
        {
            s_score = value;
            OnScoreUpdated?.Invoke();
        }
    }

    public static Action OnScoreUpdated;

    // Init on StartUp
    public override void Init()
    {
        s_score = PlayerPrefs.GetInt("Score");
    }
}
