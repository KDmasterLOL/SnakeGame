using UnityEngine;
using System.Collections;

public class LevelController : MonoBehaviour
{
    [SerializeField]
    private Level _level;

    private float _timeFood = 5, _timeLeft;

    private void Update()
    {
        _timeLeft += Time.deltaTime;
        if (_timeLeft >= LevelSettings.IntervalFoodSpawn)
        {
            _timeLeft = 0;
            _level.GenerateFood();
        }
    }
}

