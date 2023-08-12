using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    public IntChannelSO energyChanged;
    [SerializeField] private PlayerSO _playerSO;

    private void Awake()
    {
        if (instance != null && instance == this)
        {
            Destroy(this);
        } 
        else
        {
            instance = this;
        }
    }
    public void ChangeEnergyByAmount(int amount)
    {
        _playerSO.energy += amount;
        instance.energyChanged.Raise(_playerSO.energy);
    }
}
