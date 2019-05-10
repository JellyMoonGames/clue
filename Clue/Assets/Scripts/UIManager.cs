using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    // Author - Daniel Kean

    #region Inspector Variables

    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text currentCharacterText;
    [SerializeField] private RawImage currentCharacterImage;
    [SerializeField] private Text numberOfMovesText;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    #endregion

    #region Private Variables

    private CharacterSelection characterSelection;

    #endregion

    #region Methods

    private void Awake()
    {
        characterSelection = FindObjectOfType<CharacterSelection>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Detective Panel"))
        {
            if(TurnManager.CurrentCharacter.detectivePanel) ToggleObject(TurnManager.CurrentCharacter.detectivePanel);
        }

        if(Input.GetButtonDown("Pause"))
        {
            if(pauseMenu) ToggleObject(pauseMenu);          
        }

        if(currentCharacterText) currentCharacterText.text = "CURRENT CHARACTER: " + TurnManager.CurrentCharacter.Name.ToUpper();
        if(numberOfMovesText) numberOfMovesText.text = TurnManager.CurrentCharacter.CurrentNumberOfMoves.ToString() + "/" + TurnManager.CurrentRollAmount.ToString();
        if(masterVolumeSlider) AudioListener.volume = masterVolumeSlider.value;
        if(currentCharacterImage) currentCharacterImage.texture = TurnManager.CurrentCharacter.characterImage.texture;
    }

    /// <summary>
    /// Toggle the activity of this object to whatever it's currently not.
    /// </summary>
    public void ToggleObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    /// <summary>
    /// Open a scene by passing in its name.
    /// </summary>
    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Update the 'textObject' with the string text that is passed in.
    /// </summary>
    public void UpdateText(Text textObject, string text)
    {
        textObject.text = text;
    }

    /// <summary>
    /// Select a character that will be player selected when the main scene is loaded.
    /// </summary>
    public void ChooseCharacter(Character character)
    {
        if(CharacterSelection.CurrentNumberOfPlayers >= CharacterSelection.NumberOfPlayers) return;

        CharacterSelection.ChosenCharacters.Add(character);
        characterSelection.DisableCharacterButton(character.Name);

        CharacterSelection.CurrentNumberOfPlayers++;
    }

    /// <summary>
    /// Close the game when this method is called.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }

    #endregion
}
