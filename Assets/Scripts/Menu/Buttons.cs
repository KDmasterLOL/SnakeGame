using UnityEngine;
using UnityEngine.SceneManagement;
public class Buttons : MonoBehaviour
{
    public void Play() => SceneManager.LoadScene(1, LoadSceneMode.Single);

}

