using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Sunflower : Entity
{
    public VoidChannelSO EnergySupplied;

    [SerializeField] private ParticleSystem _particleSystem;

    private int energyGain = 1;
    public override void DoAction()
    {
        GameManager.instance.ChangeEnergyByAmount(energyGain);
        _particleSystem.Emit(1);
        EnergySupplied.Raise();
    }
}
