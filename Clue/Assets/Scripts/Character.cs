using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { Player, AI, NonPlaying };

public class Character : BoardPiece
{
    /// <summary>
    /// This represents each character that will be present 
    /// on the board.
    /// 
    /// Author - Daniel Kean
    /// </summary>

    #region Public Properties

    public string Name { get { return characterName; } set { characterName = value; } }
    public PlayerType Type { get; private set; }
    public bool IsInRoom { get; set; }
    public int CurrentNumberOfMoves { get { return tileStack.Count - 1; } }
    public Tile CurrentTile { get; set; }
    public Tile PreviousTile { get; set; }
    public Motor Motor { get; set; }

    #endregion

    #region Inspector Variables

    [SerializeField] private string characterName = "Default Character Name";
    [SerializeField] private Sprite characterImage;

    #endregion

    #region Private Variables

    private Stack<Tile> tileStack = new Stack<Tile>();

    #endregion

    #region Methods

    private void Start()
    {
        //Debug.Log("Character Start: " + Name);

        IsMoving = false;

        PreviousTile = CurrentTile;
        CurrentTile.AddCharacter(this);
        tileStack.Push(CurrentTile);
    }

    private void Update()
    {
        // Return from the update if this isn't this character's turn.
        if((TurnManager.CurrentCharacter.Name == Name) == false || TurnManager.CurrentCharacter.IsInRoom)
        {
            return;
        }

        if(Input.GetButtonDown("Up"))           Move(CurrentTile.GetNeighbour("Up"));
        else if(Input.GetButtonDown("Down"))    Move(CurrentTile.GetNeighbour("Down"));
        else if(Input.GetButtonDown("Left"))    Move(CurrentTile.GetNeighbour("Left"));
        else if(Input.GetButtonDown("Right"))   Move(CurrentTile.GetNeighbour("Right"));
    }

    public bool Move(Tile targetTile)
    {
        // Move to the 'targetTile' and keep track of all of the previous
        // tiles that the character has gone to in their turn. Returns true
        // if the character moved successfully to the target tile.

        if(targetTile == null || IsMoving) return false;

        // TO-DO: FIX BUG WHERE PREVIOUS TILE ISN'T CORRECT
        #region Assign Previous Tile

        Tile tempCurrentTile = tileStack.Peek();

        tileStack.Pop();

        if(tileStack.Count > 0) PreviousTile = tileStack.Peek();
        else PreviousTile = CurrentTile;

        tileStack.Push(tempCurrentTile);
        CurrentTile = tileStack.Peek();

        #endregion

        if(targetTile == PreviousTile)
        {
            tileStack.Pop();
            Debug.Log("PREVIOUS");
        }
        else
        {
            tileStack.Push(targetTile);
            Debug.Log("FORWARD");
        }

        CurrentTile.RemoveCharacter(this);
        CurrentTile = tileStack.Peek();
        CurrentTile.AddCharacter(this);

        StartCoroutine(Utilities.Movement(this, CurrentTile.transform.position, 0.15f));

        return true;
    }

    public void ResetMoveCount()
    {
        tileStack.Clear();
        tileStack.Push(CurrentTile);
        PreviousTile = CurrentTile;
    }

    #endregion
}