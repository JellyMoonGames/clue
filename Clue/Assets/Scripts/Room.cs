using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    /// This represents the Rooms that will be on the game board.
    /// It is responsible for storing all of the current weapons
    /// and players that are in the room.
    /// </summary>

    #region Public Properties

    // TO-DO: ADD A LIST FOR THE CURRENT WEAPONS ONCE ITS CLASS HAS BEEN CREATED
    public List<Character> CurrentCharacters { get; private set; } = new List<Character>();

    #endregion

    #region Inspector Variables

    [SerializeField] private string roomName = "Default Room Name";

    #endregion

    #region Methods

    public void AddCharacter(Character character)
    {
        CurrentCharacters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        if(CurrentCharacters.Contains(character))
        {
            Debug.LogError("The character wasn't in the room");
            return;
        }

        CurrentCharacters.Remove(character);
    }

    // TO-DO: IMPLEMENT 'AddCharacters' METHOD ONCE A WEAPON CLASS HAS BEEN CREATED

    #endregion
}
