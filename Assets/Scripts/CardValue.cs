using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CardValue : MonoBehaviour
{
    public CardsSO CardsSO;
    public Image CardFront;
    public int CardNumberValue;
    

    public void CardsValue()
    {
        CardFront.sprite = CardsSO.CardImage;
        CardNumberValue = CardsSO.CardValue;

    }
    
}
