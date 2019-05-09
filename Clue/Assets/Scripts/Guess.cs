using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guess
{
    /// <summary>
    /// Represents a guess that a player can make in the game and stores
    /// the character, weapon and room that they have chosen.
    /// </summary>

    #region Public Properties

    public Character Accuser { get; private set; } = null;
    public Character Character { get; private set; }
    public Weapon Weapon { get; private set; }
    public Room Room { get; private set; }

    #endregion
}