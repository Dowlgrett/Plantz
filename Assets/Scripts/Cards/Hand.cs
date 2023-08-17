using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public static Hand instance { get; private set; }
    public Card SelectedCard => _selectedCard;
    private Card _selectedCard;
    [SerializeField] private List<Card> _cards;
    public List<Card> Cards => _cards;
    [SerializeField] private CardBuilder _cardBuilder;
    private void Awake()
    {
        if (instance != null && instance == this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        foreach (Card card in _cards)
        {
            _cardBuilder.AddCardAsChildToParent(card.CardSO, transform);
        }
    }
    public Card SelectCard(Card card)
    {
        _selectedCard = card;
        return _selectedCard;
    }
}
