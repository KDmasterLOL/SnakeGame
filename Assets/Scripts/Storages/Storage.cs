
using System;
using UnityEngine;

abstract public class Storage<T>
{
    private static T[] s_items = null;

    private static int _current;

    public static T Current => s_items[_current];

    public static void Set(T[] items)
    {
        Debug.Log($"Setting {typeof(T).Name} storage");

        if (s_items.IsNullOrEmpty() == false || items.IsNullOrEmpty())
        {
            Debug.Log($"Storage {typeof(T).Name} isn't set");

            return;
        }
        else
        {
            s_items = items;

            Debug.Log($"Storage {typeof(T).Name} setted");
        }
    }
}
static class ExtensionsMethods
{
    public static bool IsNullOrEmpty(this Array array)
    {
        return (array == null || array.Length == 0);
    }
}