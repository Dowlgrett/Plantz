using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardSO")]
public class CardSO : ScriptableObject
{
    [SerializeField] private string _title;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _cost;
    [SerializeField] [TextArea] private string _description;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Type _cardType;

    public enum Type
    {
        Plant,
        Tile,
    }

    public string Title => _title;
    public Sprite Sprite => _sprite;
    public int Cost => _cost;
    public string Description => _description;
    public GameObject PlantPrefab => _prefab;

    public Type CardType => _cardType;

}
