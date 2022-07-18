using System.Collections.Generic;
using UnityEngine;

public class SnakePlayer : Initialise
{
    private SnakeHead _head;
    private List<SnakeBody> _bodies;
    private SnakeTail _tail;

    private int _length = 0;

    public SnakePart.Direction Direction => _head.CurrentDirection;

    public void Move(SnakePart.Direction direction)
    {
        _head.CurrentDirection = direction;
        _tail.Move();
    }

    public void Expand()
    {
        SnakeBody body = SkinsStorage.Current.Body;

        body.Init(transform, _tail.transform.position, _tail.CurrentDirection);
        body.Next = _bodies[^1];
        body.gameObject.SetActive(false);
        _tail.Next = body;
        _bodies.Add(body);

        _length += 1;
    }

    public override void Init()
    {
        Vector3 position = new(0, 1, -1);

        _head = SkinsStorage.Current.Head;
        _head.Init(transform, position);

        position.y--;
        _bodies = new List<SnakeBody> { SkinsStorage.Current.Body };
        _bodies[0].Init(transform, position);

        position.y--;
        _tail = SkinsStorage.Current.Tail;
        _tail.Init(transform, position);

        _tail.Next = _bodies[0];
        _bodies[0].Next = _head;
        _length = 1;
    }
}