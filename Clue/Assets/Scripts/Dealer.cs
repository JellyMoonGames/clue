using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    // Author - Daniel Kean

    /// <summary>
    /// Manages creating the different card decks and distributing
    /// them to the different players. It is also responsible for
    /// shuffling the cards so that they're random and spawning
    /// them onto the board.
    /// </summary>

    #region Public Properties

    public Queue<Card> CharacterDeck { get; private set; }
    public Queue<Card> WeaponDeck { get; private set; }
    public Queue<Card> RoomDeck { get; private set; }
    public Queue<Card> ClueDeck { get; private set; }

    #endregion

    #region Inspector Variables

    [SerializeField] private List<Card> characterCards;
    [SerializeField] private List<Card> weaponCards;
    [SerializeField] private List<Card> roomCards;
    [SerializeField] private List<Card> clueCards;

    #endregion

    #region Methods

    private void Awake()
    {
        CreateDecks();
    }

    /// <summary>
    /// Spawns the cards onto the board at the correct locations.
    /// </summary>
    public void SpawnCards()
    {

    }

    /// <summary>
    /// Returns a random number between 2 and 12 which represents the
    /// 2 dices that would be rolled.
    /// </summary>
    public static int RollDice()
    {
        return Random.Range(2, 12);
    }

    /// <summary>
    /// Takes the lists of the different card types and creates a randomised
    /// deck for each type, represented as a queue.
    /// </summary>
    private void CreateDecks()
    {
        Utilities.ShuffleList(characterCards);
        Utilities.ShuffleList(weaponCards);
        Utilities.ShuffleList(roomCards);
        Utilities.ShuffleList(clueCards);

        CharacterDeck = new Queue<Card>(characterCards);
        WeaponDeck = new Queue<Card>(weaponCards);
        RoomDeck = new Queue<Card>(roomCards);
        ClueDeck = new Queue<Card>(clueCards);
    }

    #endregion
}
