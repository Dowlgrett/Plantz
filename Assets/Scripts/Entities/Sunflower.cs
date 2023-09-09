using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Sunflower : Entity
{
    private void Awake()
    {
        var damageable = GetComponent<Health>();
    }

    [SerializeField] private ParticleSystem _particleSystem;

    private int energyGain = 1;
    public override void DoAction()
    {
        GameManager.Instance.ChangeEnergyByAmount(energyGain);
        EventManager.Instance.TriggerEnergySuppliedEvent(energyGain);

        _particleSystem.Emit(1);
    }
}
