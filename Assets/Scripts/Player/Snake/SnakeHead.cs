using UnityEngine;
using System;

public sealed class SnakeHead : SnakePart
{
    static public event Action OnFood;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision is null) return;
        if (collision.transform.CompareTag(Tags.Food))
        {
            Destroy(collision.gameObject);
            OnFood?.Invoke();
        }
    }
}