using System;
using UnityEngine;

using static SnakePart.Direction;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player _player;

    private float _pastTime = 0;

    private SnakePart.Direction _direction = Up;

    [SerializeField]
    private float _timeStep = 1;

    private void Update()
    {
        ProcessInput();
        CountTimeToMove();
    }

    private void CountTimeToMove()
    {
        _pastTime += Time.deltaTime;
        if (_pastTime >= _timeStep)
        {
            _pastTime = 0;
            _player.Move(_direction);
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

        _direction = direction;
    }
}