using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardObject : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public TextMeshProUGUI suitText;

    public void SetCard(int number, string suitName)
    {
        numberText.text = number.ToString();
        suitText.text = suitName;
    }
}
