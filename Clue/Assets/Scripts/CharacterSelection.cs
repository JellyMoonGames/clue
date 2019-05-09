using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// Manages what characters that the player selects when they're
    /// setting up the board that should be player controlled.
    /// </summary>

    #region Static Variables

    public static List<Character> ChosenCharacters = new List<Character>();
    public static int NumberOfPlayers = 0;
    public static int CurrentNumberOfPlayers = 0;
    public static bool HasSetNumberOfPlayers = false;

    #endregion

    #region Inspector Variables

    [SerializeField] private InputField numOfPlayersInputField;
    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject scarlettButton;
    [SerializeField] private GameObject mustardButton;
    [SerializeField] private GameObject plumButton;
    [SerializeField] private GameObject peacockButton;
    [SerializeField] private GameObject greenButton;
    [SerializeField] private GameObject whiteButton;

    #endregion

    #region Private Variables

    private bool runOnce_DisableCharacterSelection = false;

    #endregion

    #region Methods

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        numOfPlayersInputField.onEndEdit.AddListener(delegate { SetNumberOfPlayers(int.Parse(numOfPlayersInputField.text)); });
    }

    private void Update()
    {
        Debug.Log("Current:" + CurrentNumberOfPlayers);
        Debug.Log("Max: " + NumberOfPlayers);

        foreach(Character character in ChosenCharacters)
        {
            Debug.Log(character);
        }

        if(CurrentNumberOfPlayers >= NumberOfPlayers && runOnce_DisableCharacterSelection == false && HasSetNumberOfPlayers)
        {
            characterSelection.SetActive(false);
            startGameButton.SetActive(true);
            runOnce_DisableCharacterSelection = true;
        }
    }

    /// <summary>
    /// Sets the number of characters that the player can
    /// choose to be player controlled.
    /// </summary>
    private void SetNumberOfPlayers(int amount)
    {
        if(amount < 0 || amount > 6) return;

        NumberOfPlayers = amount;
        numOfPlayersInputField.gameObject.SetActive(false);
        characterSelection.gameObject.SetActive(true);
        HasSetNumberOfPlayers = true;
    }

    /// <summary>
    /// Disable the character button with the given character name.
    /// </summary>
    public void DisableCharacterButton(string name)
    {
        switch(name)
        {
            case "Miss Scarlett"    : scarlettButton.SetActive(false);  break;
            case "Colonel Mustard"  : mustardButton.SetActive(false);   break;
            case "Professor Plum"   : plumButton.SetActive(false);      break;
            case "Mr Green"         : greenButton.SetActive(false);     break;
            case "Mrs White"        : whiteButton.SetActive(false);     break;
            case "Mrs Peacock"      : peacockButton.SetActive(false);   break;
        }
    }

    #endregion
}
