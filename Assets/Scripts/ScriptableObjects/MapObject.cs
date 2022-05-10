using UnityEngine;

[CreateAssetMenu(fileName = "Map", menuName = "ScriptableObjects/Map", order = 1)]
class MapObject : ScriptableObject
{
    [SerializeField]
    private Map _map;

    public Map Map => _map;
}