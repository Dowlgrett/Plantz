using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardVisual : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        GetComponent<Card>().DeselectEvent += OnDeselect;
        GetComponent<Card>().SelectEvent += OnSelect;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale *= 1.2f;
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale /= 1.2f;
        transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z);
    }

    public void OnDeselect(Card lastClickedCard)
    {
        _image.color = lastClickedCard.DefaultColor;
    }

    public void OnSelect(Card clickedCard)
    {
        if (clickedCard.GetComponent<Image>().color == clickedCard.SelectedColor) //TODO: change check for color
            clickedCard.GetComponent<Image>().color = clickedCard.DefaultColor;
        else
            _image.color = clickedCard.SelectedColor;
    }
}

