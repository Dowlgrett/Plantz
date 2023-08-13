using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Sunflower : Entity
{

    [SerializeField] private int _health; //TODO: make it into Scriptable object

    private void Awake()
    {
        var damageable = GetComponent<Damageable>();
        damageable.SetHealth(_health);
    }

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
