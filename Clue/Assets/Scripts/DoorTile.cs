using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTile : Tile
{
    /// <summary>
    /// Represents the tiles that allows a character to
    /// enter a room.
    /// </summary>

    #region Inspector Variables

    [SerializeField] public Room attachedRoom;

    #endregion

    #region Methods

    private new void Awake()
    {
        base.Awake();
    }

    #endregion
}