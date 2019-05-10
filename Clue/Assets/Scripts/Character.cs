using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { Player, AI, NonPlaying };

public class Character : BoardPiece
{
    // Author - Daniel Kean

    /// <summary>
    /// This represents each character that will be present 
    /// on the board.
    /// </summary>

    #region Public Properties

    public string Name { get { return characterName; } set { characterName = value; } }
    public PlayerType Type { get; set; }
    public bool IsInRoom { get; set; }
    public int CurrentNumberOfMoves { get { return tileStack.Count - 1; } }
    public Tile CurrentTile { get; set; }
    public Tile PreviousTile { get; set; }
    public Motor Motor { get; set; }

    #endregion

    #region Inspector Variables

    [SerializeField] private string characterName = "Default Character Name";
    public Sprite characterImage;
    public GameObject detectivePanel;

    #endregion

    #region Private Variables

    private Stack<Tile> tileStack = new Stack<Tile>();
    private bool runOnce_AIMovement = false;

    #endregion

    #region Methods

    private void Start()
    {
        IsMoving = false;

        PreviousTile = CurrentTile;
        CurrentTile.AddCharacter(this);
        tileStack.Push(CurrentTile);

        detectivePanel.transform.parent = FindObjectOfType<Canvas>().transform;
        detectivePanel.transform.localScale = new Vector3(1f, 1f, 1f);
        detectivePanel.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
    }

    private void Update()
    {
        // Return from the update if this isn't this character's turn.
        if((TurnManager.CurrentCharacter.Name == Name) == false || TurnManager.CurrentCharacter.IsInRoom)
        {
            return;
        }

        if(Type == PlayerType.Player)
        {
            PlayerMotor playerMotor = Motor as PlayerMotor;
            Tile targetTile = playerMotor.ProcessMovement();
            Move(targetTile);
        }
        else if(Type == PlayerType.AI && runOnce_AIMovement == false)
        {
            AIMotor aiMotor = Motor as AIMotor;
            int randomMoveAmount = Random.Range(1, TurnManager.CurrentRollAmount);
            Debug.Log(randomMoveAmount);

            for(int i = 0; i < randomMoveAmount; i++)
            {
                Tile targetTile = aiMotor.ProcessMovement();
                Move(targetTile);
                Debug.Log("MOVEMENT TICK");
            }

            TurnManager.EndTurn();
            runOnce_AIMovement = true;
        }
    }

    /// <summary>
    /// Moves this character to the target tile and keeps track of the
    /// previous tiles that it has visited. Returns true if the character
    /// successfully moved to the target tile.
    /// </summary>
    public bool Move(Tile targetTile)
    {
        if(targetTile == null || IsMoving) return false;

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

    /// <summary>
    /// Resets the number of moves that the player has made
    /// and clears the tile history.
    /// </summary>
    public void ResetMoveCount()
    {
        tileStack.Clear();
        tileStack.Push(CurrentTile);
        PreviousTile = CurrentTile;
        runOnce_AIMovement = false;
    }

    #endregion
}