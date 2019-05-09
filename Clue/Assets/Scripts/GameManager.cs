using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GameState { PlayerTurn, Guessing, Interaction, GameOver }

public class GameManager : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// This manages the game state and stores the global lists of
    /// characters and weapons. It also fires off events which other
    /// classes can react to.
    /// </summary>

    #region Public Properties

    public static GameState GameState;
    public static Character[] Characters = new Character[6];
    public static Room[] Rooms = new Room[9];
    public static Tile[] Tiles = new Tile[220];
    public static List<Weapon> Weapons = new List<Weapon>();
    public static Guess CorrectGuess;

    #endregion

    #region Events

    public static UnityAction OnGameOver;

    #endregion

    #region Methods

    /// <summary>
    /// Compares the passed in guess with the correct guess.
    /// </summary>
    public static void MakeGuess(Guess guess)
    {
        if(guess.Character == CorrectGuess.Character && guess.Weapon == CorrectGuess.Weapon && guess.Room == CorrectGuess.Room)
        {
            Win(guess.Accuser);
        }
    }

    /// <summary>
    /// Called when a player makes a correct guess.
    /// </summary>
    private static void Win(Character character)
    {
        GameState = GameState.GameOver;
        OnGameOver();
    }

    #endregion
}