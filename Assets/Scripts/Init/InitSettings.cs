using UnityEngine;

public class InitSettings : Initialise
{
    [SerializeField]
    private float TimeFoodSpawn, TimeSnakeStep;

    public override void Init()
    {
        LevelSettings.IntervalFoodSpawn = TimeFoodSpawn;
        PlayerSettings.TimeSnakeStep = TimeSnakeStep;
    }
}

