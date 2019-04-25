using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    /// This represents the rooms that will be on the game board.
    /// It is responsible for storing all of the current weapons
    /// and players that are in the room.
    /// 
    /// Author - Daniel Kean
    /// </summary>

    #region Public Properties

    // TO-DO: ADD A LIST FOR THE CURRENT WEAPONS ONCE ITS CLASS HAS BEEN CREATED
    public List<Character> CurrentCharacters { get; private set; } = new List<Character>();
    public List<Weapon> CurrentWeapons { get; private set; } = new List<Weapon>();

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
        if(CurrentCharacters.Contains(character) == false)
        {
            Debug.LogError("The character wasn't in the room");
            return;
        }

        CurrentCharacters.Remove(character);
    }

    public void AddWeapon(Weapon weapon)
    {
        CurrentWeapons.Add(weapon);
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if(CurrentWeapons.Contains(weapon) == false)
        {
            Debug.LogError("The weapon wasn't in the room");
            return;
        }

        CurrentWeapons.Remove(weapon);
    }

    #endregion
}
