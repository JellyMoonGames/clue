using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTileInteraction : Interaction
{
    // Author - Daniel Kean

    /// <summary>
    /// Manages what happens when the player clicks on a door tile.
    /// </summary>

    #region Private Variables

    private DoorTile doorTile;

    #endregion

    #region Methods

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

    #endregion
}
