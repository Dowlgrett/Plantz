using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource plantPlaced;
    public AudioSource energySupplied;
    [SerializeField] private PlantPlacer _plantPlacer;
    public VoidChannelSO EnergySupplied;

    private void Start()
    {
        _plantPlacer.PlantPlaced += OnPlantPlaced;
        EnergySupplied.EventRaised += OnEnergySupplied;


    }

    void OnPlantPlaced()
    {
        plantPlaced.Play();
    }

    void OnEnergySupplied()
    {
        energySupplied.Play();
    }


}
