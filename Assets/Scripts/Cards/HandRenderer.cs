using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRenderer : MonoBehaviour
{
    [SerializeField] private CardBuilder _cardBuilder;

    private void Start()
    {
        foreach (Card card in Hand.instance.Cards)
        {
            _cardBuilder.AddCardAsChildToParent(card.CardSO, transform);
        }
    }


}
