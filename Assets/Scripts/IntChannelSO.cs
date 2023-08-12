using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Int Channel")]
public class IntChannelSO : ScriptableObject
{
    public event Action<int> EventRaised;

    public void Raise(int value)
    {
        EventRaised?.Invoke(value);
    }
}