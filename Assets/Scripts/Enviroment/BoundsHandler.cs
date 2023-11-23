using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsHandler : MonoBehaviour
{
    [HideInInspector]
    public Collider2D[] LevelBounds;
    void Start()
    {
        LevelBounds = GetComponentsInChildren<Collider2D>();
    }
}
