using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foods : MonoBehaviour
{
    private static List<Food> _foods = new List<Food>();

    private void Start()
    {
        _foods.Clear();
    }

    public int MaxAttemps = 3;
    public void CreateFood()
    {
        Vector3 position = Vector3.zero;
        for (int attemps = 0; attemps < MaxAttemps; attemps++)
        {
            position = Level.RandomCoordOnMap;
            if (Physics2D.OverlapPoint(position) == null)
            {
                _foods.Add(MapsStorage.Current.CreateFood(position));
                break;
            }
        }
    }

    public static void DeleteFood(Food item) => _foods.Remove(item);
}
