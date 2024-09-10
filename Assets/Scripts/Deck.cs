using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    private List<CardDataType.Card> deck;

    // Start is called before the first frame update
    void Start()
    {
        BuildDeck();
        ShuffleDeck();

        for (int x = 0; x < deck.Count; x++)
            deck[x].DebugShowCard();
    }


    // Creates a full deck of 52 cards
    public void BuildDeck()
    {
        deck = new List<CardDataType.Card>();

        for (int num = 1; num <= 13; num++)
            for (int suit = 0; suit < 4; suit++)
                deck.Add(new CardDataType.Card(num, (CardDataType.Suit)suit));
    }


    // Adds a Card to the top of the deck
    public void AddCard(CardDataType.Card card)
    {
        deck.Add(card);

        if (deck.Count == 53)
            Debug.LogError("Deck exceeded max limit of 52");
    }


    // Draws a card from the top of the pile (index 51, when at full deck) and returns its value while removing that same card from the deck
    public CardDataType.Card DrawCard()
    {
        if (deck.Count == 0)
            Debug.LogError("Tried to Draw Card while deck was Empty");

        CardDataType.Card tempCard;

        tempCard = deck[deck.Count - 1];
        deck.Remove(tempCard);

        return tempCard;
    }


    // Shuffles the current deck regardless of size
    public void ShuffleDeck()
    {
        List<CardDataType.Card> tempDeck = new List<CardDataType.Card>();
        CardDataType.Card tempCard;

        while (deck.Count > 0)
        {
            tempDeck.Add(deck[0]);
            deck.Remove(deck[0]);
        }

        while (tempDeck.Count > 0)
        {
            tempCard = tempDeck[Random.Range(0, tempDeck.Count - 1)];

            deck.Add(tempCard);
            tempDeck.Remove(tempCard);
        }
    }

}
