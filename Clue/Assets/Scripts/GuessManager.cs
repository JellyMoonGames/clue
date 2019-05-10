using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GuessState { Character, Weapon, Room };

public class GuessManager : MonoBehaviour
{
    public static GuessState CurrentGuessState { get; set; }
    public static Character CurrentCharacter { get; set; }
    public static Weapon CurrentWeapon { get; set; }
    public static Room CurrentRoom { get; set; }

    public static Guess MakeGuess()
    {
        return new Guess(CurrentCharacter, CurrentWeapon, CurrentRoom);
    }

    private void Update()
    {
        Debug.Log(CurrentGuessState);
    }
}
