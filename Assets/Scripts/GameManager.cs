using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PlayerSO _playerSO;

    private EventManager _eventManager; 

    private void Awake()
    {
        _eventManager = new EventManager();

        if (Instance != null && Instance == this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }
    }
    public void ChangeEnergyByAmount(int amount)
    {
        _playerSO.energy += amount;
        EventManager.Instance.TriggerEnergyChangedEvent(_playerSO.energy);
    }
}
