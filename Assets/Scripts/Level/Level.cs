using UnityEngine;
using System.Collections;

public class Level : Initialise
{
    private Map _map;

    private Food _food = null;

    public void GenerateFood()
    {
        var position = new Vector3(Random.Range(-_map.SizeX, _map.SizeX + 1), Random.Range(-_map.SizeY, _map.SizeY + 1), -1);
        _food = MapsStorage.Current.CreateFood(position);
    }


    public override void Init()
    {
        _map = Instantiate(MapsStorage.Current.Map, new(), new(), transform);
    }
}
