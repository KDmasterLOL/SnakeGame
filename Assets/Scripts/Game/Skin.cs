using UnityEngine;

[System.Serializable]
struct Skin
{
    [SerializeField]
    private Sprite _head;
    [SerializeField]
    private Sprite[] _bodies;
    [SerializeField]
    private Sprite[] _roundedBodies;
    [SerializeField]
    private Sprite _tail;

    public Sprite HeadSprite => _head;
    public Sprite BodySprite => _bodies[0];
    public Sprite RoundedBodySprite => _roundedBodies[0];
    public Sprite TailSprite => _tail;
}