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
    public static Tile[] Tiles = new Tile[220];
    public static List<Weapon> Weapons = new List<Weapon>();
    public static Guess CorrectGuess;

    #endregion

    #region Methods

    private void Update()
    {
        for(int i = 0; i < Characters.Length; i++)
        {
            Debug.Log(Characters[i]);
        }
    }

    #endregion
}