using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTile : Tile
{
    [SerializeField] private Room attachedRoom;

    public void EnterRoom(Character character)
    {
        if(attachedRoom == null)
        {
            Debug.LogError("There is no room assigned to this tile.");
            return;
        }

        attachedRoom.AddCharacter(character);
    }
}
