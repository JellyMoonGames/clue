using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteraction : Interaction
{
    // Author - Daniel Kean

    /// <summary>
    /// Manages what happens when the player clicks on a weapon.
    /// </summary>

    #region Private Variables

    private Weapon weapon;

    #endregion

    #region Methods

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    public override void PrimaryButton()
    {
        GameManager.GameState = GameState.Interaction;

        if(GameManager.GameState == GameState.Interaction)
        {
            RoomTile roomTile = TurnManager.CurrentCharacter.CurrentTile as RoomTile;
            Room targetRoom = null;

            try { targetRoom = roomTile.transform.parent.parent.GetComponent<Room>(); }
            catch { }

            if(targetRoom) targetRoom.AddWeapon(weapon);
        }
    }

    public override void SecondaryButton()
    {

    }

    #endregion
}
