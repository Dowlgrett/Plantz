using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Void Channel")]
public class VoidChannelSO : ScriptableObject
{
    public event Action EventRaised;
    public void Raise()
    {
        EventRaised?.Invoke();
    }

}
