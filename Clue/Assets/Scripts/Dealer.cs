using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    [SerializeField] private List<Card> characterCards;
    [SerializeField] private List<Card> weaponCards;
    [SerializeField] private List<Card> roomCards;
    [SerializeField] private List<Card> clueCards;

    public Queue<Card> CharacterDeck { get; private set; }
    public Queue<Card> WeaponDeck { get; private set; }
    public Queue<Card> RoomDeck { get; private set; }
    public Queue<Card> ClueDeck { get; private set; }

    private void Awake()
    {
        CreateDecks();
    }

    public void SpawnCards()
    {

    }

    public static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while(n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);

            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static int RollDice()
    {
        return Random.Range(2, 12);
    }

    private void CreateDecks()
    {
        ShuffleList(characterCards);
        ShuffleList(weaponCards);
        ShuffleList(roomCards);
        ShuffleList(clueCards);

        CharacterDeck = new Queue<Card>(characterCards);
        WeaponDeck = new Queue<Card>(weaponCards);
        RoomDeck = new Queue<Card>(roomCards);
        ClueDeck = new Queue<Card>(clueCards);
    }
}
