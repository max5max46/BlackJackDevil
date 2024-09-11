using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [Header("References")]
    public Deck deck;
    public TextMeshProUGUI deckValueText;
    public GameObject cardPrefab;

    [Header("Properties")]
    [SerializeField] private bool isPlayer = true;

    [HideInInspector] public int handValue;
    private List<CardDataType.Card> hand;
    private List<GameObject> gameObjectHand;

    // Start is called before the first frame update
    void Awake()
    {
        gameObjectHand = new List<GameObject>();

        ResetHand();
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

        FindAndSetHandValue();
    }


    public void FindAndSetHandValue()
    {
        handValue = 0;

        for (int i = 0; i < hand.Count; i++)
        {
            int cardValue = hand[i].number;

            if (cardValue > 10)
                cardValue = 10;

            if (cardValue != 1)
                handValue += cardValue;
        }

        for (int i = 0; i < hand.Count; i++)
        {
            int cardValue = hand[i].number;

            if (cardValue == 1)
            {
                if (handValue <= 10)
                    cardValue = 11;

                handValue += cardValue;
            }
        }

        if (isPlayer)
            deckValueText.text = "Hand Value: " + handValue;
        else
            Debug.Log("Devils Hand Value: " + handValue);
    }
}
