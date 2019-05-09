using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : Tile
{
    // Author - Daniel Kean

    /// <summary>
    /// Represents the tiles that characters will
    /// spwan on at the beginning of the game.
    /// </summary>

    #region Methods

    private new void Awake()
    {
        base.Awake();
    }

    /// <summary>
    /// Spawns the passed in character on this tile, being controlled by the passed in motor.
    /// </summary>
    public void SpawnCharacter(Character character, Motor motor)
    {
        Character characterClone = Instantiate(character, transform.position, Quaternion.identity);
        AddCharacter(characterClone);
        characterClone.Motor = motor;
    }

    #endregion
}