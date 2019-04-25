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

    public static List<Character> Characters = new List<Character>();
    public static List<Weapon> Weapons = new List<Weapon>();
    public static Guess CorrectGuess;

    #endregion
}
