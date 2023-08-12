using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.Android;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private CardSO _cardSO;
    public CardSO CardSO => _cardSO;
    
    public event Action<Card> DeselectEvent;
    public event Action<Card> SelectEvent;

    public void InitializeCard(CardSO cardSO)
    {
        UpdateImageSprites(cardSO);
        UpdateTextContents(cardSO);
        _cardSO = cardSO;
    }
   
    [SerializeField] private Color _defaultColor = Color.white;
    public Color DefaultColor => _defaultColor;

    [SerializeField] private Color _selectedColor = Color.green;
    public Color SelectedColor => _selectedColor;

    //TODO: colors shoul be in the cardVisual class, so are image contents and text i think

    private Image[] _images;
    private TMP_Text[] _textComponents;

    private void Awake()
    {
        _images = GetComponentsInChildren<Image>();
        _textComponents = GetComponentsInChildren<TMP_Text>();
    }
    private void Start()
    {
        InitializeCard(_cardSO);
    }
    private void UpdateImageSprites(CardSO cardSO)
    {
        foreach (Image image in _images)
        {
            if (image.transform != transform)
            {
                image.sprite = cardSO.Sprite;
            }
        }
    }
    private void UpdateTextContents(CardSO cardSO)
    {
        foreach (TMP_Text textComponent in _textComponents)
        {
            if (textComponent.name == "Title")
            {
                textComponent.text = cardSO.Title;
            }
            else
            {
                textComponent.text = cardSO.Description;
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        bool clickedCardIsSelectedCard = Hand.instance.SelectedCard == this;
        bool someCardIsSelected = Hand.instance.SelectedCard != null;

        if (clickedCardIsSelectedCard)
        {
            Hand.instance.SelectedCard.DeselectEvent?.Invoke(this);
            Hand.instance.SelectCard(null);
        }
        else if (someCardIsSelected)
        {
            Hand.instance.SelectedCard.DeselectEvent?.Invoke(this);
            Hand.instance.SelectCard(this);
            Hand.instance.SelectedCard.SelectEvent?.Invoke(this);
        }
        else
        {
            Hand.instance.SelectCard(this);
            Hand.instance.SelectedCard.SelectEvent?.Invoke(this);
        }
    }


}
