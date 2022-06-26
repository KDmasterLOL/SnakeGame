using UnityEngine;
using UnityEditor;
public class Function : EditorWindow
{
    [MenuItem("Window/Edit Mode Functions")]
    public static void Func()
    {
        Camera camera = Camera.allCameras[0];
        if (camera is null) Debug.Log("NULL!!!");
        Debug.Log(camera.WorldToViewportPoint(new(0, 5, 0)));
    }

    void Start()
    {

    }

    void Update()
    {

    }
}

