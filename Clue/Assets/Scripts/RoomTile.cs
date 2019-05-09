using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTile : Tile
{
    // Author - Daniel Kean

    /// <summary>
    /// Represents the tiles that board pieces will go to
    /// when they enter a room.
    /// </summary>

    #region Public Properties

    public BoardPiece CurrentBoardPiece { get; private set; }

    #endregion

    #region Methods

    /// <summary>
    /// Add the passed in board piece as this tile's current board piece.
    /// </summary>
    public void AddBoardPiece(BoardPiece boardPiece)
    {
        CurrentBoardPiece = boardPiece;

        Character character = CurrentBoardPiece as Character;
        if(character != null) character.CurrentTile = this;
    }

    /// <summary>
    /// Sets the current board piece to null.
    /// </summary>
    public void RemoveCurrentBoardPiece()
    {
        //Character character = CurrentBoardPiece as Character;
        //if(character != null) character.CurrentTile = null;

        CurrentBoardPiece = null;
    }

    #endregion
}
