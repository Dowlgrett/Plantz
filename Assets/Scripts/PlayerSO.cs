using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Player")]
public class PlayerSO : ScriptableObject
{
    [SerializeField] private int _energyDefault = 0;
    public int EnergyDefault => _energyDefault;
    [HideInInspector] public int energy;
  
    
    private void OnEnable()
    {
        energy = _energyDefault;
    }
}
