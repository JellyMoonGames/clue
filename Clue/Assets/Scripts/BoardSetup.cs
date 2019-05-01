using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSetup : MonoBehaviour
{
    /// <summary>
    /// Manages how the board is set up and spawns in the
    /// characters around it.
    /// </summary>
    
    #region Inspector Variables

    [SerializeField] private Character[] characters;
    [SerializeField] private StartTile[] startTiles;

    #endregion

    #region Private Variables

    private int startTileIndexCount = 0;

    #endregion

    #region Methods

    private void Awake()
    {
        CharacterSetup();
    }

    private void CharacterSetup()
    {
        if(startTiles.Length == 0)
        {
            Debug.LogError("Couldn't Find any start tiles.");
            return;
        }

        for(int i = 0; i < characters.Length; i++)
        {
            StartTile currentStartTile = startTiles[startTileIndexCount];
            startTileIndexCount++;

            currentStartTile.SpawnCharacter(characters[i]); 
        }
    }

    #endregion
}