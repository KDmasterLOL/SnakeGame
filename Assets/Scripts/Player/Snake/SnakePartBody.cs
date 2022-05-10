public abstract class SnakePartBody : SnakePart
{
    public SnakePart Next = null;

    public override void Move()
    {
        base.Move();
        CurrentDirection = Next.CurrentDirection;
        Next.Move();
    }
}

