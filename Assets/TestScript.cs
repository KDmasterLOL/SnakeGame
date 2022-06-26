using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public Vector3 From, To;
    public Transform target;
    void Start()
    {
        var point = transform.InverseTransformPoint(target.position);

        var angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void FixedUpdate()
    {
        //transform.rotation = Quaternion.FromToRotation(From, To);
    }
}
