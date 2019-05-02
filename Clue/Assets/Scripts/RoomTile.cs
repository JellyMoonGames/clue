using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTile : Tile
{
    /// <summary>
    /// Represents the tiles that allows a character to
    /// enter a room.
    /// </summary>

    #region Inspector Variables

    [SerializeField] private Room attachedRoom;

    #endregion

    #region Methods

    public void EnterRoom(Character character)
    {
        if(attachedRoom == null)
        {
            Debug.LogError("There is no room assigned to this tile.");
            return;
        }

        attachedRoom.AddCharacter(character);
        StartCoroutine(character.Movement(attachedRoom.GetRandomObjectPosition().position, 0.15f));
    }

    #endregion
}