using System;
using UnityEngine;

using static SnakePart.Direction;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private float _pastTime = 0;

    private SnakePart.Direction _direction = Up;

    private void Update()
    {
        if (Input.anyKeyDown) ProcessInput();
    }

    private void FixedUpdate()
    {
        CountTimeToMove();
    }

    private void CountTimeToMove()
    {
        _pastTime += Time.fixedDeltaTime;
        if (_pastTime >= PlayerSettings.TimeSnakeStep)
        {
            _pastTime = 0;
            _player._snake.Move(_direction);
        }

    }

    private void ProcessInput()
    {
        SnakePart.Direction direction = _direction;
        if (Input.GetKeyDown(KeyCode.A))
            direction = Left;
        else if (Input.GetKeyDown(KeyCode.D))
            direction = Right;
        else if (Input.GetKeyDown(KeyCode.S))
            direction = Down;
        else if (Input.GetKeyDown(KeyCode.W))
            direction = Up;

        if (_player._snake.Direction == direction || _player._snake.Direction.IsEqualByModule(direction) == false)
            _direction = direction;
    }
    private void OnEnable()
    {
        SnakeHead.OnFood += () => _player._snake.Expand();
    }
}
