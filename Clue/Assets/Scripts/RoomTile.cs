using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTile : Tile
{
    public BoardPiece CurrentBoardPiece { get; private set; }

    public void AddBoardPiece(BoardPiece boardPiece)
    {
        CurrentBoardPiece = boardPiece;

        Character character = CurrentBoardPiece as Character;
        if(character != null) character.CurrentTile = this;
    }

    public void RemoveCurrentBoardPiece()
    {
        //Character character = CurrentBoardPiece as Character;
        //if(character != null) character.CurrentTile = null;

        CurrentBoardPiece = null;
    }
}
