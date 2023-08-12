using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurnManager : MonoBehaviour
{
    private bool _isPlayerTurn = true;

    private Queue<Entity> turnQueue;

    private void Start()
    {
        turnQueue = new Queue<Entity>();
    }

    private void PopulateTurnQueue()
    {
        var entities = FindObjectsOfType<Entity>();

        foreach (Entity entity in entities)
        {
            turnQueue.Enqueue(entity);
        }
    }
    public void OnEndTurn(float delaySeconds)
    {
        if (_isPlayerTurn)
            StartCoroutine(PerformActionsOnEntities(delaySeconds));
    }
     private IEnumerator PerformActionsOnEntities(float delaySeconds)
    {
        _isPlayerTurn = false;

        var playerInput = FindObjectOfType<PlayerInput>();
        playerInput.currentActionMap.Disable();

        //TODO: should also disable buttons and stuff

        PopulateTurnQueue();

        while (turnQueue.Count > 0)
        {
            Entity currentEntity = turnQueue.Dequeue();
            currentEntity.DoAction();
            yield return new WaitForSeconds(delaySeconds);
        }

        playerInput.currentActionMap.Enable();
        _isPlayerTurn = true;
    }

    public void OnSpawn(Entity newEnemy) //should spawn by listening to an event of a spawnManager
    {
        turnQueue.Enqueue(newEnemy);
    }
}