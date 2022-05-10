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
        var obj = new GameObject();

        obj.transform.localScale = new(1, 1, 1);
        SpriteRenderer spriteRenderer = obj.AddComponent<SpriteRenderer>();
        spriteRenderer.color = Color.white;
        spriteRenderer.sprite = sprite;
        return obj;
    }
}
