using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerType { Player, AI, NonPlaying };

public class Character : MonoBehaviour
{
    /* Summary
     * This is the class that represents each character
     * that is in the game.
     * 
     * Author - Daniel Kean
    */

    #region Public Properties

    public PlayerType Type { get; private set; }
    public bool IsMoving { get; private set; }
    public int CurrentNumberOfMoves { get { return tileStack.Count - 1; } }

    #endregion

    #region Inspector Variables

    [SerializeField] private string characterName = "Default Character Name";
    [SerializeField] private Sprite characterImage;

    #endregion

    #region Private Variables

    //TO-DO: MAKE THESE PUBLIC PROPERTIES ONCE THEY DON'T HAVE TO BE SET IN THE INSPECTOR
    [SerializeField] private Tile currentTile;
    [SerializeField] private Tile previousTile;

    private Stack<Tile> tileStack = new Stack<Tile>();

    #endregion

    private void Start()
    {
        IsMoving = false;
        transform.position = currentTile.transform.position;

        previousTile = currentTile;
        tileStack.Push(currentTile);
    }

    private void Update()
    {
        // Temporary input control to test character movement
        if(Input.GetButtonDown("Up"))           Move(currentTile.GetNeighbour("Up"));
        else if(Input.GetButtonDown("Down"))    Move(currentTile.GetNeighbour("Down"));
        else if(Input.GetButtonDown("Left"))    Move(currentTile.GetNeighbour("Left"));
        else if(Input.GetButtonDown("Right"))   Move(currentTile.GetNeighbour("Right"));
    }

    public bool Move(Tile targetTile)
    {
        // Move to the 'targetTile' and keep track of all of the previous
        // tiles that the character has gone to in their turn. Returns true
        // if the character moved successfully to the target tile.

        if(targetTile == null || IsMoving) return false;

        // TO-DO : FIX BUG WHERE PREVIOUS TILE ISN'T CORRECT
        #region Assign Previous Tile

        Tile tempCurrentTile = tileStack.Peek();

        tileStack.Pop();

        if(tileStack.Count > 0) previousTile = tileStack.Peek();
        else previousTile = currentTile;

        tileStack.Push(tempCurrentTile);
        currentTile = tileStack.Peek();

        #endregion

        if(targetTile == previousTile)
        {
            tileStack.Pop();
            Debug.Log("PREVIOUS");
        }
        else
        {
            tileStack.Push(targetTile);
            Debug.Log("FORWARD");
        }

        currentTile = tileStack.Peek();
        StartCoroutine(Movement(currentTile.transform.position, 0.15f));

        return true;
    }

    private IEnumerator Movement(Vector3 target, float duration)
    {
        // This is a method to move the character over time to a target position at a
        // speed set by the 'duration' parameter.

        if(IsMoving) yield break;

        IsMoving = true;
        float counter = 0;

        while(counter < duration)
        {
            counter += Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, target, counter / duration);
            yield return null;
        }

        IsMoving = false;
    }
}
