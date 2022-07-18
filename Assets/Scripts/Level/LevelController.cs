using UnityEngine;
using System.Collections;

public class LevelController : Initialise
{
    [SerializeField]
    private Level _level;
    

    private void Update()
    {
        
    }
    private void OnEnable()
    {
        SnakeHead.OnGameOver += _level.GameOver;
    }
    private void OnDisable()
    {
        SnakeHead.OnGameOver -= _level.GameOver;
    }

    public override void Init()
    {
        _level.CreateMap();
        _level.InitPlayer();
    }
}

