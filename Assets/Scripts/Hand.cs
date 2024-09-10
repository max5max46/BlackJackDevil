using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("References")]
    public Deck deck;
    public GameObject cardPrefab;

    private int handValue;
    private List<CardDataType.Card> hand;
    private List<GameObject> gameObjectHand;

    // Start is called before the first frame update
    void Start()
    {
        ResetHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetHand()
    {
        while (gameObjectHand.Count > 0)
        {
            Destroy(gameObjectHand[0]);
            gameObjectHand.Remove(gameObjectHand[0]);
        }

        handValue = 0;
        hand = new List<CardDataType.Card>();
        gameObjectHand = new List<GameObject>();
    }

    public void DrawCard()
    {
        GameObject currentCard;

        hand.Add(deck.DrawCard());

        currentCard = Instantiate(cardPrefab);
        currentCard.GetComponent<CardObject>().SetCard(hand[hand.Count - 1].number, hand[hand.Count - 1].suitName);
        currentCard.transform.parent = transform;
        currentCard.transform.localPosition = Vector3.zero;
        currentCard.transform.localScale = Vector3.one;

        gameObjectHand.Add(currentCard);
    }

    public void FindAndSetHandValue()
    {

    }
}
