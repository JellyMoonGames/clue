using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    /// <summary>
    /// This represents all of the tiles that will make
    /// up the game board.
    /// 
    /// Author - Daniel Kean
    /// </summary>

    #region Public Properties

    public List<Character> CurrentCharacters { get; private set; } = new List<Character>();
    public bool IsOccupied { get { return CurrentCharacters.Count > 1; } }

    #endregion

    #region Inspector Variables

    protected Tile upNeighbour;
    protected Tile downNeighbour;
    protected Tile leftNeighbour;
    protected Tile rightNeighbour;

    #endregion

    #region Methods

    protected void Awake()
    {
        AssignNeighbours();
    }

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
        //if(targetTile == null) Debug.Log("A neighbour in the direction specified could not be found");

        return targetTile;
    }

    private void AssignNeighbours()
    {
        // For each direction...
        for(int d = 0; d < 4; d++)
        {
            Tile neighbour;
            RaycastHit2D hit;

            switch(d)
            {
                case 0:
                    hit = Physics2D.CircleCast(transform.position + new Vector3(0f, 1f, 0f), 0.01f, Vector2.zero);
                    if(hit) { neighbour = hit.transform.GetComponent<Tile>(); upNeighbour = neighbour; }
                break;

                case 1:
                    hit = Physics2D.CircleCast(transform.position + new Vector3(0f, -1f, 0f), 0.01f, Vector2.zero);
                    if(hit) { neighbour = hit.transform.GetComponent<Tile>(); downNeighbour = neighbour; }
                    break;

                case 2:
                    hit = Physics2D.CircleCast(transform.position + new Vector3(-1f, 0f, 0f), 0.01f, Vector2.zero);
                    if(hit) { neighbour = hit.transform.GetComponent<Tile>(); leftNeighbour = neighbour; }
                    break;

                case 3:
                    hit = Physics2D.CircleCast(transform.position + new Vector3(1f, 0f, 0f), 0.01f, Vector2.zero);
                    if(hit) { neighbour = hit.transform.GetComponent<Tile>(); rightNeighbour = neighbour; }
                    break;
            }
        }
    }

    public void AddCharacter(Character character)
    {
        // Assign the 'CharacterSlot' to the parameter given if it isn't already occupied.
        CurrentCharacters.Add(character);
        character.CurrentTile = this;
    }

    public void RemoveCharacter(Character character)
    {
        CurrentCharacters.Remove(character);
        character.CurrentTile = null;
    }

    #endregion
}
