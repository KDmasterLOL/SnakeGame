using UnityEngine;

[SerializeField]
class Map : MonoBehaviour
{
    public int SizeX => (int)Mathf.Floor(transform.lossyScale.x/2);
    public int SizeY => (int)Mathf.Floor(transform.lossyScale.y / 2);
}
