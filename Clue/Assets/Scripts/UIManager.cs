using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject detectivePanel;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Text currentCharacterText;
    [SerializeField] private Text numberOfMovesText;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;

    private void Awake()
    {

    }

    private void Update()
    {
        if(Input.GetButtonDown("Detective Panel"))
        {
            if(detectivePanel) ToggleObject(detectivePanel);
        }

        if(Input.GetButtonDown("Pause"))
        {
            if(pauseMenu) ToggleObject(pauseMenu);
        }

        if(currentCharacterText) currentCharacterText.text = "CURRENT CHARACTER: " + TurnManager.CurrentCharacter.Name.ToUpper();
        if(numberOfMovesText) numberOfMovesText.text = TurnManager.CurrentCharacter.CurrentNumberOfMoves.ToString() + "/" + TurnManager.CurrentRollAmount.ToString();
        if(masterVolumeSlider) AudioListener.volume = masterVolumeSlider.value;
    }

    public void ToggleObject(GameObject gameObject)
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void OpenScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateText(Text textObject, string text)
    {
        textObject.text = text;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
