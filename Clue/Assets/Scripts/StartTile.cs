using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTile : Tile
{
    /// <summary>
    /// Represents the tiles that characters will
    /// spwan on at the beginning of the game.
    /// </summary>

    #region Methods

    private new void Awake()
    {
        base.Awake();
    }

    public void SpawnCharacter(Character character, Motor motor)
    {
        Character characterClone = Instantiate(character, transform.position, Quaternion.identity);
        AddCharacter(characterClone);
        characterClone.Motor = motor;

        // TO-DO: SET UP CHARACTER PROPERTIES, I.E. IF THEY'RE PLAYER CONTROLLED OR AI.
    }

    #endregion
}