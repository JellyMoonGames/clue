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
    [SerializeField] private Weapon[] weapons;

    #endregion

    #region Private Variables

    private int startTileIndexCount = 0;
    private CharacterSelection characterSelection;

    #endregion

    #region Methods

    private void Awake()
    {
        characterSelection = FindObjectOfType<CharacterSelection>();
    }

    private void Start()
    {
        FindTiles();
        FindRooms();
        CharacterSetup();
        FindCharacters();
        WeaponSetup();
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

            Motor motor = null;

            foreach(Character chosenCharacter in CharacterSelection.ChosenCharacters)
            {
                if(characters[i].Name == chosenCharacter.Name) motor = new PlayerMotor();
                else motor = new AIMotor();
            }

            currentStartTile.SpawnCharacter(characters[i], motor); 
        }
    }

    private void WeaponSetup()
    {
        List<Weapon> weaponList = new List<Weapon>();

        for(int i = 0; i < weapons.Length; i++)
        {
            weaponList.Add(weapons[i]);
        }

        for(int i = 0; i < GameManager.Rooms.Length; i++)
        {
            if(weaponList.Count <= 0) return;

            Weapon randomWeapon = weaponList[Random.Range(0, weaponList.Count - 1)];
            RoomTile randomRoomTile = GameManager.Rooms[i].GetRandomRoomTile();

            Weapon weaponClone = Instantiate(randomWeapon, randomRoomTile.transform.position, randomRoomTile.transform.rotation);
            GameManager.Rooms[i].AddWeapon(weaponClone);

            weaponList.Remove(randomWeapon);
        }
    }

    private static void FindCharacters()
    {
        Character[] characters = FindObjectsOfType<Character>();

        //for(int i = 0; i < characters.Length; i++) Debug.Log(characters[i]);

        for(int i = 0; i < characters.Length; i++)
        {
            // Defines the order in which characters have their turns.
            if(characters[i].Name == "Miss Scarlett")           GameManager.Characters[0] = characters[i];
            else if(characters[i].Name == "Colonel Mustard")    GameManager.Characters[1] = characters[i];
            else if(characters[i].Name == "Professor Plum")     GameManager.Characters[2] = characters[i];
            else if(characters[i].Name == "Mr Green")           GameManager.Characters[3] = characters[i];
            else if(characters[i].Name == "Mrs White")          GameManager.Characters[4] = characters[i];
            else if(characters[i].Name == "Mrs Peacock")        GameManager.Characters[5] = characters[i];
        }
    }

    public static void FindRooms()
    {
        GameManager.Rooms = FindObjectsOfType<Room>();
    }

    public static void FindTiles()
    {
        GameManager.Tiles = FindObjectsOfType<Tile>();
    }

    #endregion
}