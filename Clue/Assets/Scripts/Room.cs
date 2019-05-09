using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    /// <summary>
    /// This represents the rooms that will be on the game board.
    /// It is responsible for storing all of the current weapons
    /// and players that are in the room.
    /// 
    /// Author - Daniel Kean
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

    public void EnterRoom(Character character)
    {
        CurrentCharacters.Add(character);
        character.CurrentTile.RemoveCharacter(character);

        RoomTile roomTile = GetRandomRoomTile();
        roomTile.AddBoardPiece(character);
        character.IsInRoom = true;

        StartCoroutine(Utilities.Movement(character, roomTile.transform.position, 0.15f));

    }

    public void LeaveRoom(Character character, Tile exitTile)
    {
        if(CurrentCharacters.Contains(character) == false)
        {
            Debug.LogError("The character wasn't in the room");
            return;
        }

        CurrentCharacters.Remove(character);

        RoomTile roomTile = character.CurrentTile as RoomTile;
        roomTile.RemoveCurrentBoardPiece();
        character.IsInRoom = false;

        character.Move(exitTile);
    }

    public void AddWeapon(Weapon weapon)
    {
        CurrentWeapons.Add(weapon);
        StartCoroutine(Utilities.Movement(weapon, GetRandomRoomTile().transform.position, 0.15f));
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if(CurrentWeapons.Contains(weapon) == false)
        {
            Debug.LogError("The weapon wasn't in the room");
            return;
        }

        CurrentWeapons.Remove(weapon);
    }

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