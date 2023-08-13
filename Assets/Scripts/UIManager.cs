using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private TMP_Text _energyTMP;
    public IntChannelSO energyChanged;
    public PlayerSO player;
    private void Start()
    {
        _energyTMP = GameObject.Find("EnergyTMP").GetComponent<TMP_Text>();
        _energyTMP.text = player.EnergyDefault.ToString();
        energyChanged.EventRaised += OnEnergyChanged;
    }
    private void OnEnergyChanged(int energy)
    {
        _energyTMP.text = energy.ToString();
    }
}
