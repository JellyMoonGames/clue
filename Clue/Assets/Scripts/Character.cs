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

    #endregion

    #region Inspector Variables

    [SerializeField] private string characterName = "Default Character Name";
    [SerializeField] private Sprite characterImage;

    #endregion

    //TO-DO
    public bool Move()
    {
        return true;
    }

    //TO-DO
    public bool FinishMove()
    {
        return true;
    }
}
