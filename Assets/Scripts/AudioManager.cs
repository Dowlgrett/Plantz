using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _plantPlaced;
    [SerializeField] private AudioSource _energySupplied;
    [SerializeField] private AudioSource _enemyHit;

    [SerializeField] private PlantPlacer _plantPlacer;

    public VoidChannelSO EnergySupplied;

    private void Start()
    {
        _plantPlacer.PlantPlaced += OnPlantPlaced;
        EnergySupplied.EventRaised += OnEnergySupplied;

    }

    private void OnPlantPlaced()
    {
        _plantPlaced.Play();
    }

    public void OnEnemyHit() //TODO: public
    {
        _enemyHit.Play();
    }

    private void OnEnergySupplied()
    {
        _energySupplied.Play();
    }
}
