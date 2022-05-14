using UnityEngine;

public class InitSettings : Initialise
{
    [SerializeField]
    private float TimeFoodSpawn, TimeSnakeStep;

    public override void Init()
    {
        LevelSettings.TimeFoodSpawn = TimeFoodSpawn;
        PlayerSettings.TimeSnakeStep = TimeSnakeStep;
    }
}

