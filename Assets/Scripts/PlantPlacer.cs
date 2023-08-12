using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantPlacer : MonoBehaviour
{
    private Tilemap _tilemap;
    private Dictionary<GameObject, Vector3Int> _plantedPlants;
    private InputController _inputController;
    [SerializeField] private PlayerSO _playerSO;

    public event Action PlantPlaced;

    private void Awake()
    { 
        _plantedPlants = new Dictionary<GameObject, Vector3Int>();
        _inputController = GetComponent<InputController>();
    }

    private void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();

    }

    private void OnEnable()
    {
        _inputController.ClickedToPlant += OnPlantPlaced;
    }

    private void OnDisable()
    {
        _inputController.ClickedToPlant -= OnPlantPlaced;
    }

    public void OnPlantPlaced(Vector3 mouseClickPosition)
    {
        Vector3Int cell = _tilemap.WorldToCell(mouseClickPosition);

        if (_plantedPlants.ContainsValue(cell))
            return;
 
        if (_tilemap.HasTile(_tilemap.WorldToCell(mouseClickPosition)))
        {     
            Vector3 cellWorldPosition = _tilemap.GetCellCenterWorld(cell);           
            Card card = Hand.instance.SelectedCard;

            if (card != null && _playerSO.energy >= card.CardSO.Cost)
            {
                _plantedPlants.Add(Instantiate(card.CardSO.PlantPrefab.gameObject, cellWorldPosition, Quaternion.identity), cell);
                PlantPlaced?.Invoke();

                Destroy(card.gameObject);

                //who is responsible for deselecting destroyed card? TODO: fix this

                GameManager.instance.ChangeEnergyByAmount(-card.CardSO.Cost);
            }
        }
    }
}
