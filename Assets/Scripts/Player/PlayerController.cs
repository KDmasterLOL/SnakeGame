using System;
using UnityEngine;

using static SnakePart.Direction;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private SnakePlayer Snake;

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
            Snake.Move(_direction);
        }
        _isExpended = false;
        Expand();
    }

    private int _registeredExpands = 0;
    private bool _isExpended = false;

    private void RegisterExpand() => _registeredExpands++;

    private void Expand()
    {
        if (_registeredExpands == 0 || _isExpended)
            return;
        _registeredExpands--;
        Snake.Expand();
        _isExpended = true;
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

        if (Snake.Direction == direction || Snake.Direction.IsEqualByModule(direction) == false)
            _direction = direction;
    }
    private void OnEnable()
    {
        SnakeHead.OnTakeFood += RegisterExpand;
    }
    private void OnDisable()
    {
        SnakeHead.OnTakeFood -= RegisterExpand;
    }
}
