using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private TMP_Text _energyTMP;
    public PlayerSO player;

    [SerializeField] private Button _endTurnButton;

    private void Start()
    {
        _energyTMP = GameObject.Find("EnergyTMP").GetComponent<TMP_Text>(); //racing conditions for events
        _energyTMP.text = player.EnergyDefault.ToString();
        EventManager.Instance.EnergyChangedEvent += OnEnergyChanged;
        EventManager.Instance.EndTurnButtonPressedEvent += DisableButton;
        EventManager.Instance.PlayerTurnStartedEvent += EnableButton;
        EventManager.Instance.RewardSelectedEvent += EnableButton;
        EventManager.Instance.RewardScreenPoppedUpEvent += DisableButton;
    }

    private void EnableButton()
    {
        _endTurnButton.interactable = true;
    }

    private void DisableButton()
    {
        _endTurnButton.interactable = false;
    }

    private void OnEnergyChanged(int energy)
    {
        _energyTMP.text = energy.ToString();
    }


}
