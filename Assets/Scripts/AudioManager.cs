using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _plantPlaced;
    [SerializeField] private AudioSource _energySupplied;
    [SerializeField] private AudioSource _enemyHit;

    private void Start()
    {
        EventManager.Instance.PlantPlacedEvent += OnCardEntityPlaced;
        EventManager.Instance.EnergySuppliedEvent += OnEnergySupplied;
    }

    private void OnCardEntityPlaced(GameObject entity, Vector3Int cell)
    {
        _plantPlaced.Play();
    }

    public void OnEnemyHit() //TODO: why is it public
    {
        _enemyHit.Play();
    }

    private void OnEnergySupplied(int energyAmount)
    {
        _energySupplied.Play();
    }
}
