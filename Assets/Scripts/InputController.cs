using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class InputController : MonoBehaviour
{
    private void OnPlace()
    {
        Vector3 position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        EventManager.Instance.TriggerClickedToPlantEvent(position);
    }
}
