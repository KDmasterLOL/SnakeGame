using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(BoxCollider2D), typeof(Rigidbody2D))]
abstract public class SnakePart : MonoBehaviour
{

    protected Direction _direction = Direction.Up;
    protected Rigidbody2D _rigidbody2D;
    protected bool _isInitialized = false;
    public virtual Direction CurrentDirection
    {
        get => _direction;
        set => UpdateDirection(value);

    }

    protected Sprite SnakeSprite;

    public virtual void Move()
    {
        var vector = Vector3.zero;
        switch (CurrentDirection)
        {
            default:
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

        vector = transform.position + vector;
        if (Math.Abs(vector.x) == MapsStorage.Current.Map.SizeX + 1)
            vector.x = transform.position.x > 0 ? -MapsStorage.Current.Map.SizeX : MapsStorage.Current.Map.SizeX;
        else if (Math.Abs(vector.y) == MapsStorage.Current.Map.SizeY + 1)
            vector.y = transform.position.y > 0 ? -MapsStorage.Current.Map.SizeY : MapsStorage.Current.Map.SizeY;
        _rigidbody2D.MovePosition(vector);
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

        float rotation = 0;

        switch (_direction)
        {
            case Direction.Up:
                rotation = 0;
                break;
            case Direction.Down:
                rotation = 180;
                break;
            case Direction.Left:
                rotation = 90;
                break;
            case Direction.Right:
                rotation = -90;
                break;
        }

        _rigidbody2D.SetRotation(rotation);
    }

    private void Awake()
    {
        SetComponentVar();
    }

    protected virtual void SetComponentVar()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Init(Transform parent, Vector3 position, Direction direction = Direction.Up)
    {
        if (_isInitialized) return;
        transform.SetParent(parent);
        transform.position = position;
        _direction = direction;
        UpdateDirection(direction);
        _isInitialized = true;
    }
}