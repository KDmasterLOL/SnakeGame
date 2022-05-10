using System;
using UnityEngine;

static public class ExtensionMethods
{
    static public GameObject SetParametrs(this GameObject obj, Transform parent = null, Vector3 position = new(), Quaternion rotaion = new())
    {
        obj.transform.position = position;
        if (parent is not null) obj.transform.SetParent(parent);
        obj.transform.rotation = rotaion;
        return obj;
    }
    static public bool IsEqualByModule(this SnakePart.Direction first, SnakePart.Direction second)
    {
        if (Math.Abs((int)first) == Math.Abs((int)second)) return true;
        else return false;
    }
}

