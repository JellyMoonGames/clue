using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { PlayerTurn, Guessing, GameOver }

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// This manages the game state and stores the global lists of
    /// characters and weapons. It also fires off events which other
    /// classes can react to.
    /// 
    /// Author - Daniel Kean
    /// </summary>

    #region Public Properties

    public static GameState GameState;
    public static Character[] Characters = new Character[6];
    public static Room[] Rooms = new Room[9];
    public static List<Weapon> Weapons = new List<Weapon>();
    public static Guess CorrectGuess;

    #endregion

    #region Methods

    private void Awake()
    {
        FindCharacters();
        FindRooms();
    }

    private static void FindCharacters()
    {
        Character[] characters = FindObjectsOfType<Character>();

        for(int i = 0; i < characters.Length; i++)
        {
            // Defines the order in which characters have their turns.
            if(characters[i].Name == "Miss Scarlett")           Characters[0] = characters[i];
            else if(characters[i].Name == "Colonel Mustard")    Characters[1] = characters[i];
            else if(characters[i].Name == "Professor Plum")     Characters[2] = characters[i];
            else if(characters[i].Name == "Mr Green")           Characters[3] = characters[i];
            else if(characters[i].Name == "Mrs White")          Characters[4] = characters[i];
            else if(characters[i].Name == "Mrs Peacock")        Characters[5] = characters[i];
        }
    }

    private static void FindRooms()
    {
        Rooms = FindObjectsOfType<Room>();
    }

    #endregion
}