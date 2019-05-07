using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    public static Tile[] Tiles = new Tile[220];
    public static List<Weapon> Weapons = new List<Weapon>();
    public static Guess CorrectGuess;

    #endregion

    #region Events

    public static UnityAction OnGameOver;

    #endregion

    #region Methods

    public static void MakeGuess(Guess guess)
    {
        if(guess.Character == CorrectGuess.Character && guess.Weapon == CorrectGuess.Weapon && guess.Room == CorrectGuess.Room)
        {
            Win(guess.Accuser);
        }
    }

    private static void Win(Character character)
    {
        GameState = GameState.GameOver;
        OnGameOver();
    }

    #endregion
}