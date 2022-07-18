using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodsController : MonoBehaviour
{
    [SerializeField]
    private Foods FoodsLevel;

    private float _timeLeft;

    void Update()
    {
        _timeLeft += Time.deltaTime;
        if (_timeLeft >= LevelSettings.IntervalFoodSpawn)
        {
            _timeLeft = 0;
            FoodsLevel.CreateFood();
        }
    }
}
