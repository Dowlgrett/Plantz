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
        Vector3Int clickedCell = _tilemap.WorldToCell(mouseClickPosition);

        if (_plantedPlants.ContainsValue(clickedCell))
            return;
 
        if (_tilemap.HasTile(clickedCell))
        {     
            Vector3 cellCenterWorldPosition = _tilemap.GetCellCenterWorld(clickedCell);           
            Card card = Hand.instance.SelectedCard;

            if (card != null && _playerSO.energy >= card.CardSO.Cost)
            {
                GameObject plant = Instantiate(card.CardSO.PlantPrefab.gameObject, cellCenterWorldPosition, Quaternion.identity);
                _plantedPlants.Add(plant, clickedCell);
                GameObject tileObject = _tilemap.GetInstantiatedObject(clickedCell);
                if (tileObject.TryGetComponent<GrassTileObject>(out var grassTileObjectComponent))
                {
                    grassTileObjectComponent.SetObjectOnTile(plant);
                }

                PlantPlaced?.Invoke();

                Destroy(card.gameObject);

                GameManager.instance.ChangeEnergyByAmount(-card.CardSO.Cost);
            }
        }
    }
}
