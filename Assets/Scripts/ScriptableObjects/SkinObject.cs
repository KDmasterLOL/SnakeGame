using UnityEngine;

[CreateAssetMenu(fileName = "Skin", menuName = "ScriptableObjects/Skin", order = 1)]
class SkinObject : ScriptableObject
{
    [SerializeField]
    private Skin _skin;

    public Skin Skin => _skin;

    public SnakeHead Head => CreateObject(_skin.HeadSprite).AddComponent<SnakeHead>();
    public SnakeBody Body => CreateObject(_skin.BodySprite).AddComponent<SnakeBody>();
    public SnakeTail Tail => CreateObject(_skin.TailSprite).AddComponent<SnakeTail>();

    private GameObject CreateObject(Sprite sprite)
    {
        var obj = new GameObject("BodyPart", typeof(SpriteRenderer),typeof(BoxCollider2D),typeof(Rigidbody2D));
        obj.tag = Tags.Player;

        BoxCollider2D collider2D = obj.GetComponent<BoxCollider2D>();
        collider2D.size = new(0.5f, 0.5f);

        Rigidbody2D rigidbody2D = obj.GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;

        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        return obj;
    }
}
