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

    public void SpawnCharacter(Character character)
    {
        Character characterClone = Instantiate(character, transform.position, Quaternion.identity);
        characterClone.CurrentTile = this;
        SetCharacter(characterClone);

        // TO-DO: SET UP CHARACTER PROPERTIES, I.E. IF THEY'RE PLAYER CONTROLLED OR AI.
    }

    #endregion
}