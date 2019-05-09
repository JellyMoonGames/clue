using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public static List<Character> ChosenCharacters = new List<Character>();

    [SerializeField] private InputField numOfPlayersInputField;
    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject startGameButton;
    [SerializeField] private GameObject scarlettButton;
    [SerializeField] private GameObject mustardButton;
    [SerializeField] private GameObject plumButton;
    [SerializeField] private GameObject peacockButton;
    [SerializeField] private GameObject greenButton;
    [SerializeField] private GameObject whiteButton;

    public static int NumberOfPlayers = 0;
    public static int CurrentNumberOfPlayers = 0;
    private bool runOnce_DisableCharacterSelection = false;
    public static bool HasSetNumberOfPlayers = false;

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

    private void SetNumberOfPlayers(int amount)
    {
        if(amount < 0 || amount > 6) return;

        NumberOfPlayers = amount;
        numOfPlayersInputField.gameObject.SetActive(false);
        characterSelection.gameObject.SetActive(true);
        HasSetNumberOfPlayers = true;
    }

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
}
