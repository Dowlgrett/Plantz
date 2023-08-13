using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    [SerializeField] [FormerlySerializedAs("plantPlaced")] private AudioSource _plantPlaced;
    [SerializeField] [FormerlySerializedAs("energySupplied")] private AudioSource _energySupplied;
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

    private void OnEnergySupplied()
    {
        _energySupplied.Play();
    }
}
