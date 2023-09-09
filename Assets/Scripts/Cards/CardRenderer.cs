using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();

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

   
}

