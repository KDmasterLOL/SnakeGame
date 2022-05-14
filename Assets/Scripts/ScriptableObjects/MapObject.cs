using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/Map", order = 1)]
class MapObject : ScriptableObject
{
    [SerializeField]
    private Map _map;

    [SerializeField]
    private Sprite _food;

    public Map Map => _map;

    public Food CreateFood(Vector3 position)
    {
        var obj = new GameObject("Food", typeof(SpriteRenderer),typeof(BoxCollider2D), typeof(Food),typeof(Rigidbody2D));
        obj.tag = Tags.Food;

        BoxCollider2D collider2D = obj.GetComponent<BoxCollider2D>();
        collider2D.size = new(0.5f, 0.5f);
        collider2D.isTrigger = true;

        Rigidbody2D rigidbody2D = obj.GetComponent<Rigidbody2D>();
        rigidbody2D.isKinematic = true;

        obj.transform.position = position;
        obj.GetComponent<SpriteRenderer>().sprite = _food;

        return obj.GetComponent<Food>();
    }
}