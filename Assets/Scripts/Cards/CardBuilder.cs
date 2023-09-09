using UnityEngine;

public class CardBuilder : MonoBehaviour
{
    [SerializeField] private Card _cardPrefab;

    public Card AddCardAsChildToParent(CardSO cardSO, Transform parent)
    {
        Card card = Instantiate(_cardPrefab, parent);
        card.InitializeCard(cardSO);
        card.transform.SetParent(parent, false);
        return card;
    }
}
