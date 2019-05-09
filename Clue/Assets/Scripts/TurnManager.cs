using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    /// <summary>
    /// Manages whose turn it is in the game and gives
    /// control to the next player after.
    /// </summary>

    #region Public Properties

    public static Character CurrentCharacter;
    public static int CurrentRollAmount;

    #endregion

    #region Private Variables

    private int currentIndex = -1;

    #endregion

    #region Methods

    private void Start()
    {
        NextCharacter();
    }

    private void Update()
    {
        if(Input.GetKeyDown("space")) EndTurn();
    }

    public void EndTurn()
    {
        if(CurrentCharacter.CurrentNumberOfMoves > CurrentRollAmount)
        {
            Debug.Log("You have moved more tiles than you've rolled. please move back.");
            return;
        }

        if(CurrentCharacter.CurrentTile && CurrentCharacter.CurrentTile.IsOccupied)
        {
            Debug.Log("This tile is occupied, please move somewhere else.");
            return;
        }

        if(CurrentCharacter.CurrentTile.GetType() == typeof(DoorTile))
        {
            DoorTile doorTile = CurrentCharacter.CurrentTile as DoorTile;
            Room room = doorTile.attachedRoom;

            room.EnterRoom(CurrentCharacter);
        }

        NextCharacter();
    }

    private void NextCharacter()
    {
        if(currentIndex + 1 > GameManager.Characters.Length - 1)
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }

        if(CurrentCharacter) CurrentCharacter.ResetMoveCount();
        CurrentCharacter = GameManager.Characters[currentIndex];
        CurrentRollAmount = Dealer.RollDice(); 
    }

    #endregion
}