using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Motor : MonoBehaviour
{
    // Author - Daniel Kean

    public Character Character { get; private set; }

    protected void Awake()
    {
        Character = GetComponent<Character>();
    }

    public abstract Tile ProcessMovement();
}
