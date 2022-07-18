using UnityEngine;
using UnityEngine.SceneManagement;
using System;

using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    static private Map _map;
    [SerializeField]
    private SnakeController _snake;

    static public Vector3 RandomCoordOnMap { get => new Vector3(Random.Range(-_map.SizeX, _map.SizeX + 1), Random.Range(-_map.SizeY, _map.SizeY + 1), -1); }

    public void CreateMap()
    {
        _map = Instantiate(MapsStorage.Current.Map, new(), new(), transform);
    }
    public void InitPlayer()
    {
        _snake.Init();
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }


}
