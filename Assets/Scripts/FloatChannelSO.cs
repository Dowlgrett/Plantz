using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Float Channel")]
public class FloatChannelSO : ScriptableObject
{
    public event Action<float> EventRaised;

    public void Raise(float value)
    {
        EventRaised?.Invoke(value);
    }
}
