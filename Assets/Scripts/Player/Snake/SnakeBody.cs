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

    protected override void SetComponentVar()
    {
        base.SetComponentVar();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void UpdateDirection(Direction direction)
    {
        if (_direction.IsEqualByModule(direction))
        {
            base.UpdateDirection(direction);
            IsRounded = false;
            return;
        }
        else IsRounded = true;


        float rotation = 0;

        if (_direction == Direction.Up)
            rotation = direction == Direction.Left ? 90 : 180;
        else if (_direction == Direction.Down)
            rotation = direction == Direction.Left ? 0 : 270;
        else if (_direction == Direction.Left)
            rotation = direction == Direction.Down ? 180 : 270;
        else if (_direction == Direction.Right)
            rotation = direction == Direction.Down ? 90 : 0;
        _direction = direction;

        _rigidbody2D.SetRotation(rotation);
    }

}