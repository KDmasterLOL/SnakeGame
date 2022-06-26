using System;
using UnityEngine;

public abstract class SnakePartBody : SnakePart
{
    public SnakePart Next = null;

    public override void Move()
    {
        if (gameObject.activeSelf == false) gameObject.SetActive(true);
        _rigidbody2D.MovePosition(Next.transform.position);
        CurrentDirection = Next.CurrentDirection;
        Next.Move();
    }
    protected override void SetComponentVar()
    {
        base.SetComponentVar();
        gameObject.tag = Tags.Body;
        
    }
}