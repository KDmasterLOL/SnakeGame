using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
abstract public class SnakePart : MonoBehaviour
{

    protected Direction _direction = Direction.Up;

    public virtual Direction CurrentDirection
    {
        get => _direction;
        set
        {
            if (_direction.IsEqualByModule(value)) return;
            UpdateDirection(value);
        }

    }

    protected Sprite SnakeSprite;

    public virtual void Move()
    {
        var vector = Vector3.zero;
        switch (CurrentDirection)
        {
            case Direction.Up:
                vector.y = 1;
                break;
            case Direction.Down:
                vector.y = -1;
                break;
            case Direction.Left:
                vector.x = -1;
                break;
            case Direction.Right:
                vector.x = 1;
                break;
        }
        transform.position += vector;
    }

    public enum Direction
    {
        Up = 1,
        Down = -1,
        Right = 2,
        Left = -2,
    }

    protected virtual void UpdateDirection(Direction direction)
    {

        _direction = direction;

        var rotation = new Vector3();

        switch (_direction)
        {
            case Direction.Up:
                rotation = new(0, 0, 0);
                break;
            case Direction.Down:
                rotation = new(0, 0, 180);
                break;
            case Direction.Left:
                rotation = new(0, 0, 90);
                break;
            case Direction.Right:
                rotation = new(0, 0, -90);
                break;
        }
        transform.eulerAngles = rotation;
    }
}