using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BoardPiece
{
    /// <summary>
    /// This represents all the weapons that will be present
    /// on the game board.
    /// 
    /// Author - Daniel Kean
    /// </summary> 

    #region Inspector Variables

    [SerializeField] private string weaponName = "Default Weapon Name";

    #endregion
}