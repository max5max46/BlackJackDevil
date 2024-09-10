using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CardDataType
{
    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades
    }

    public struct Card
    {
        public bool faceUp;
        public int number;
        public Suit suit;
        public string suitName;

        public Card(int number = 1, Suit suit = Suit.Hearts)
        {
            faceUp = false;
            this.number = number;
            this.suit = suit;

            switch (suit)
            {
                case Suit.Hearts:
                    suitName = "Hearts";
                    break;

                case Suit.Diamonds:
                    suitName = "Diamonds";
                    break;

                case Suit.Clubs:
                    suitName = "Clubs";
                    break;

                case Suit.Spades:
                    suitName = "Spades";
                    break;

                default:
                    suitName = "Error";
                    break;
            }
        }

        public void DebugShowCard()
        {
            Debug.Log("Card is a " + number + " of " + suitName);
        }
    }
}
