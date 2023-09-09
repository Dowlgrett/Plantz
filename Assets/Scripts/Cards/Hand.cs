using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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

    private void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected != null && selected.TryGetComponent(out Card card)) {
            _selectedCard = card;
        }
        if (selected == null)
        {
            _selectedCard = null;
        }
    }

    public void AddCardToHand(CardSO addedCard)
    {
        var transform = FindObjectOfType<HandRenderer>().transform;
        _cardBuilder.AddCardAsChildToParent(addedCard, transform);
    }



}
