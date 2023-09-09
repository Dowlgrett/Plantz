using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public int Cost { get; protected set; }


    [SerializeField] protected CardSO _cardSO;
    public CardSO CardSO => _cardSO;
    private Image[] _images;
    private TMP_Text[] _textComponents;


    public void InitializeCard(CardSO cardSO)
    {
        UpdateImageSprites(cardSO);
        UpdateTextContents(cardSO);
        _cardSO = cardSO;
    }

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
}