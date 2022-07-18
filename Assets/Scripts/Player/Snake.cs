using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
public class Snake : MonoBehaviour
{
    private SnakeEntireBody _snake;

    public SnakePart.Direction Direction => _snake.Head.CurrentDirection;

    public void Move(SnakePart.Direction direction)
    {
        _snake.Head.CurrentDirection = direction;
        _snake.Tail.Move();
    }

    public void Expand()
    {
        SnakeBody body = SkinsStorage.Current.Body;

        body.Init(transform, _snake.Tail.transform.position, _snake.Tail.CurrentDirection);
        body.Next = _snake.Bodies.Last();
        body.gameObject.SetActive(false);
        _snake.Tail.Next = body;
        _snake.AddBody(body);
    }

    public void CreateSnake()
    {
        Vector3 position = new(0, 1, -1);

        var head = SkinsStorage.Current.Head;
        head.Init(transform, position);

        position.y--;
        var bodies = new List<SnakeBody> { SkinsStorage.Current.Body };
        bodies[0].Init(transform, position);

        position.y--;
        var tail = SkinsStorage.Current.Tail;
        tail.Init(transform, position);

        tail.Next = bodies[0];
        bodies[0].Next = head;

        _snake = new(head, bodies, tail);
    }
}
public struct SnakeEntireBody
{
    readonly public SnakeHead Head;
    readonly public List<SnakeBody> Bodies;
    readonly public SnakeTail Tail;
    public int Length { get; private set; }

    public SnakeEntireBody(SnakeHead head, List<SnakeBody> bodies, SnakeTail tail)
    {
        Head = head;
        Bodies = bodies;
        Tail = tail;
        Length = 3;
    }
    public void AddBody(SnakeBody body)
    {
        Bodies.Add(body);
        Length++;
    }
}