using UnityEngine;
using System;

public sealed class SnakeHead : SnakePart
{
    static public event Action OnTakeFood;
    static public event Action OnGameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is null) return;
        if (collision.transform.CompareTag(Tags.Food))
        {
            Destroy(collision.gameObject);
            OnTakeFood?.Invoke();
        }
        else if (collision.transform.CompareTag(Tags.Body))
            OnGameOver?.Invoke();
    }
    protected override void SetComponentVar()
    {
        base.SetComponentVar();
        gameObject.tag = Tags.Head;
    }
}