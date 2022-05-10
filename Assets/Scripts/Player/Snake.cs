using System.Collections.Generic;
using UnityEngine;

public class Snake : Initialise
{
    private SnakeHead _head;
    private List<SnakeBody> _bodies;
    private SnakeTail _tail;

    private int _length = 0;

    public void Move(SnakePart.Direction direction)
    {
        _head.CurrentDirection = direction;
        _tail.Move();
    }

    public void Expand()
    {
        //var body = Instantiate(playerBody, _tail.transform.position, _tail.transform.rotation, transform).AddComponent<SnakeBody>();
        //body.Next = _bodies[_bodies.Count - 1];
        //_tail.Next = body;
    }

    public override void Init()
    {
        Vector2 vector = new(0, 1);

        _head = SkinsStorage.Current.Head;
        _head.gameObject.SetParametrs(position: vector, parent: transform);

        vector.y--;
        _bodies = new List<SnakeBody> { SkinsStorage.Current.Body };
        _bodies[0].gameObject.SetParametrs(position: vector, parent: transform);

        vector.y--;
        _tail = SkinsStorage.Current.Tail;
        _tail.gameObject.SetParametrs(position: vector, parent: transform);

        _tail.Next = _bodies[0];
        _bodies[0].Next = _head;
        _length = 1;
    }
}