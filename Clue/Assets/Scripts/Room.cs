using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// This represents the rooms that will be on the game board.
    /// It is responsible for storing all of the current weapons
    /// and players that are in the room.
    /// </summary>

    #region Public Properties

    public List<Character> CurrentCharacters { get; private set; } = new List<Character>();
    public List<Weapon> CurrentWeapons { get; private set; } = new List<Weapon>();

    #endregion

    #region Inspector Variables

    [SerializeField] private string roomName = "Default Room Name";
    [SerializeField] private Room secretPassage;

    #endregion

    #region Private Variables

    private RoomTile[] roomTiles;

    #endregion

    #region Methods

    private void Awake()
    {
        roomTiles = transform.GetComponentsInChildren<RoomTile>(true);
    }

    /// <summary>
    /// Add the passed in character into this room and move them to a
    /// random room tile.
    /// </summary>
    public void EnterRoom(Character character)
    {
        CurrentCharacters.Add(character);
        character.CurrentTile.RemoveCharacter(character);

        RoomTile roomTile = GetRandomRoomTile();
        roomTile.AddBoardPiece(character);
        character.IsInRoom = true;

        StartCoroutine(Utilities.Movement(character, roomTile.transform.position, 0.15f));

    }

    /// <summary>
    /// Remove a character from this room and move them to the passed
    /// in exit tile.
    /// </summary>
    public void LeaveRoom(Character character, Tile exitTile)
    {
        if(CurrentCharacters.Contains(character) == false)
        {
            Debug.Log("The character wasn't in the room");
            return;
        }

        CurrentCharacters.Remove(character);

        RoomTile roomTile = character.CurrentTile as RoomTile;
        roomTile.RemoveCurrentBoardPiece();
        character.IsInRoom = false;

        character.Move(exitTile);
    }

    /// <summary>
    /// Add the passed in weapon to this room.
    /// </summary>
    public void AddWeapon(Weapon weapon)
    {
        CurrentWeapons.Add(weapon);
        StartCoroutine(Utilities.Movement(weapon, GetRandomRoomTile().transform.position, 0.15f));
    }

    /// <summary>
    /// Remove the passed in weapon from this room.
    /// </summary>
    public void RemoveWeapon(Weapon weapon)
    {
        if(CurrentWeapons.Contains(weapon) == false)
        {
            Debug.LogError("The weapon wasn't in the room");
            return;
        }

        CurrentWeapons.Remove(weapon);
    }

    /// <summary>
    /// Returns a random room tile that hasn't been occupied by another board piece.
    /// </summary>
    public RoomTile GetRandomRoomTile()
    {
        if(roomTiles.Length == 0)
        {
            Debug.LogError("There are no object positions for: " + roomName);
            return null;
        }

        RoomTile chosenRoomTile = roomTiles[Random.Range(0, roomTiles.Length - 1)];

        while(chosenRoomTile.CurrentBoardPiece != null)
        {
            chosenRoomTile = roomTiles[Random.Range(0, roomTiles.Length - 1)];
        }

        return chosenRoomTile;
    }

    #endregion
}