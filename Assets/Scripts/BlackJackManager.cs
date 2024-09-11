using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BlackJackManager : MonoBehaviour
{
    [Header("References")]
    public Deck deck;
    public Hand playerHand;
    public Hand devilHand;
    public UnityEngine.UI.Button hitButton;
    public UnityEngine.UI.Button standButton;

    private int amountOfStands;

    // Start is called before the first frame update
    void Start()
    {
        amountOfStands = 0;

        StartRound();
    }

    public void StartRound()
    {
        hitButton.interactable = false;
        standButton.interactable = false;

        amountOfStands = 0;

        // Resets all cards
        deck.BuildDeck();
        deck.ShuffleDeck();
        playerHand.ResetHand();
        devilHand.ResetHand();

        // Adds the first 2 cards to hand
        playerHand.DrawCard();
        devilHand.DrawCard();
        playerHand.DrawCard();
        devilHand.DrawCard();

        if (devilHand.handValue == 21)
        {
            EndRound(false);
            return;
        }

        if (playerHand.handValue == 21)
        {
            EndRound(true);
            return;
        }

        hitButton.interactable = true;
        standButton.interactable = true;
    }

    public void Stand()
    {
        hitButton.interactable = false;
        standButton.interactable = false;

        amountOfStands++;

        DevilTurn();
    }

    public void Hit()
    {
        hitButton.interactable = false;
        standButton.interactable = false;

        playerHand.DrawCard();

        if (playerHand.handValue > 21)
            EndRound(false);

        if (playerHand.handValue == 21)
            EndRound(true);

        DevilTurn();
    }

    public void DevilTurn()
    {
        if (devilHand.handValue > 17 || playerHand.handValue >= 21)
            amountOfStands++;
        else
            devilHand.DrawCard();

        TurnCheck();
    }

    public void TurnCheck()
    {
        if (devilHand.handValue > 21 || playerHand.handValue == 21)
        {
            EndRound(true);
            return;
        }

        if (devilHand.handValue == 21 || playerHand.handValue > 21)
        {
            EndRound(false);
            return;
        }

        if (amountOfStands == 2)
        {
            if (devilHand.handValue >= playerHand.handValue)
                EndRound(false);
            else
                EndRound(true);

            return;
        }

        amountOfStands = 0;

        hitButton.interactable = true;
        standButton.interactable = true;
    }

    public void EndRound(bool didPlayerWin)
    {
        if (didPlayerWin == true)
            Debug.Log("player Win");
        else
            Debug.Log("Devil Win");

        hitButton.interactable = false;
        standButton.interactable = false;

        StartRound();
    }
}
