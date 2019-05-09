using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTileInteraction : Interaction
{
    private DoorTile doorTile;

    private void Awake()
    {
        doorTile = GetComponent<DoorTile>();
    }

    public override void PrimaryButton()
    {
        doorTile.attachedRoom.LeaveRoom(TurnManager.CurrentCharacter, doorTile);
    }

    public override void SecondaryButton()
    {
        Debug.Log("ROOM TILE SECONDARY");
    }
}
