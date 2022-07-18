using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D),typeof(SpriteRenderer))]
public class Food : MonoBehaviour
{
    private void OnDestroy()
    {
        Foods.DeleteFood(this);
    }
}

