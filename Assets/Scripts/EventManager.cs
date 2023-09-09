using System;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public event Action<GameObject, Vector3Int> PlantPlacedEvent;
    public event Action<int> EnergySuppliedEvent;
    public event Action<int> EnergyChangedEvent;
    public event Action<Vector3> ClickedToPlantEvent;
    public event Action<Entity> EntityDiedEvent;
    public event Action RewardSelectedEvent;

    public event Action EndTurnButtonPressedEvent;
    public event Action PlayerTurnStartedEvent;
    public event Action RewardScreenPoppedUpEvent;

    private static EventManager _instance;
    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EventManager();
            return _instance;
        }
    }

    public void TriggerPlantPlacedEvent(GameObject entity, Vector3Int cell)
    {
        PlantPlacedEvent?.Invoke(entity, cell);
    }

    public void TriggerEnergySuppliedEvent(int energyAmount)
    {
        EnergySuppliedEvent?.Invoke(energyAmount);
    }

    public void TriggerClickedToPlantEvent(Vector3 clickPosition)
    {
        ClickedToPlantEvent?.Invoke(clickPosition);
    }

    public void TriggerEnergyChangedEvent(int newEnergyAmount)
    {
        EnergyChangedEvent?.Invoke(newEnergyAmount);
    }

    public void TriggerEntityDiedEvent(Entity diedEntity)
    {
        EntityDiedEvent?.Invoke(diedEntity);
    }

    public void TriggerRewardSelectedEvent()
    {
        RewardSelectedEvent?.Invoke();
    }

    public void TriggerEndTurnButtonPressedEvent()
    {
        EndTurnButtonPressedEvent?.Invoke();
    }

    public void TriggerPlayerTurnStartedEvent()
    {
        PlayerTurnStartedEvent?.Invoke();
    }

    public void TriggerRewardScreenPoppedUpEvent()
    {
        RewardScreenPoppedUpEvent?.Invoke();
    }


}