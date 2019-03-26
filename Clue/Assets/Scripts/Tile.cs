using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    /* Summary
     * This is the class that represents all of the tiles that
     * will be present on the game board.
     * 
     * Author - Daniel Kean
    */

    #region Public Properties

    public Character CharacterSlot { get; private set; }
    public bool IsOccupied { get { return CharacterSlot != null; } }

    #endregion

    #region Inspector Variables

    [SerializeField] private Tile upNeighbour;
    [SerializeField] private Tile downNeighbour;
    [SerializeField] private Tile leftNeighbour;
    [SerializeField] private Tile rightNeighbour;

    #endregion

    #region Methods

    public Tile GetNeighbour(string neighbourDirection)
    {
        // Return a specific neighbour of this tile based on the parameter 'neighbourDirection'
        // and if one can't be found, then an error is produced.

        Tile targetTile = null;

        switch(neighbourDirection)
        {
            case "Up"   : targetTile = upNeighbour;     break;
            case "Down" : targetTile = downNeighbour;   break;
            case "Left" : targetTile = leftNeighbour;   break;
            case "Right": targetTile = rightNeighbour;  break;
            default     : targetTile = null;            break;
        }

        // TO-DO: PLAY SOUND EFFECT TO SHOW THE PLAYER THEY CAN'T MOVE IN THAT DIRECTION 
        if(targetTile == null) Debug.LogError("A neighbour in the direction specified could not be found");

        return targetTile;
    }

    public void SetCharacter(Character character)
    {
        // Assign the 'CharacterSlot' to the parameter given if it isn't already occupied.

        CharacterSlot = character;
    }

    #endregion
}
