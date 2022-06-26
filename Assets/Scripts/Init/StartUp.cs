using UnityEngine;

public class StartUp : MonoBehaviour
{
    [SerializeReference]
    private Initialise[] _initialise;

    private void Start()
    {
        foreach (var init in _initialise)
            init.Init();
    }
}