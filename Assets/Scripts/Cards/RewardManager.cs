using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    private List<CardSO> _rewardCards;

    [SerializeField] private RewardCard _rewardCardPrefab;

    [SerializeField] private List<CardSO> _possibleRewards;

    [SerializeField] private int _rewardCount;

    void Awake()
    {
        _rewardCards = new List<CardSO>();
        GetComponent<CanvasRenderer>().cull = true;
    }

    private void Start()
    {
        EventManager.Instance.EntityDiedEvent += OnEntityDiedEvent;
        EventManager.Instance.RewardSelectedEvent += OnRewardSelectedEvent;
    }

    private void OnRewardSelectedEvent()
    {
        Time.timeScale = 1f;
        GetComponent<CanvasRenderer>().cull = true;
        
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void OnEntityDiedEvent(Entity diedEntity)
    {
        if (diedEntity != null && diedEntity.gameObject.TryGetComponent(out Hostile hostile))
        {
            Time.timeScale = 0f;
            GetComponent<CanvasRenderer>().cull = false;
            GenerateRewards();
            EventManager.Instance.TriggerRewardScreenPoppedUpEvent();
        }
    }

    void GenerateRewards()
    {
        _rewardCards.Clear();

        while (_rewardCards.Count != _rewardCount)
        {
            var randomIndex = Random.Range(0, _possibleRewards.Count);
            var newCard = _possibleRewards[randomIndex];
            if (!_rewardCards.Contains(newCard))
            {
                _rewardCards.Add(newCard);
            }        
        }

        foreach (var cardSO in _rewardCards)
        {
            var rewardCard = Instantiate(_rewardCardPrefab, gameObject.transform);
            rewardCard.InitializeCard(cardSO);
        }
    }
}
