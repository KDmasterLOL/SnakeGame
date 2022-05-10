using UnityEngine;

public sealed class SnakeBody : SnakePartBody
{
    private SpriteRenderer _spriteRenderer;
    private bool _isRounded = false;

    public override Direction CurrentDirection
    {
        get => base.CurrentDirection;
        set => UpdateDirection(value);
    }

    private bool IsRounded
    {
        get => _isRounded;
        set
        {
            if (value == _isRounded) return;
            else if (value == true) _spriteRenderer.sprite = SkinsStorage.Current.Skin.RoundedBodySprite;
            else _spriteRenderer.sprite = SkinsStorage.Current.Skin.BodySprite;
            _isRounded = value;
        }
    }


    private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();

    protected override void UpdateDirection(Direction direction)
    {
        if (_direction.IsEqualByModule(direction))
        {
            if (IsRounded) base.UpdateDirection(direction);
            IsRounded = false;
            return;
        }
        else IsRounded = true;


        Vector3 rotation = Vector3.zero;

        if (_direction == Direction.Up)
            rotation = direction == Direction.Left ? new(0, 0, 0) : new(0, 0, 90);
        else if (_direction == Direction.Down)
            rotation = direction == Direction.Left ? new(0, 0, 270) : new(0, 0, 180);
        else if (_direction == Direction.Left)
            rotation = direction == Direction.Up ? new(0, 0, 180) : new(0, 0, 90);
        else if (_direction == Direction.Right)
            rotation = direction == Direction.Up ? new(0, 0, 270) : new(0, 0, 0);
        _direction = direction;

        transform.eulerAngles = rotation;
    }
}