using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Snake _snake;

    public void Move(SnakePart.Direction direction) => _snake.Move(direction);
}