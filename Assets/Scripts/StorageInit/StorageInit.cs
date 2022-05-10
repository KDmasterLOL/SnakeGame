using UnityEngine;

[System.Serializable]
abstract public class StorageInit<T> : Initialise
{
    [SerializeField]
    protected T[] Items;
}
