using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CardTests
{
    [UnityTest]
    public IEnumerator PlayerHasFiveCardsAtTheStart()
    {
        GameObject hand = new GameObject();
        hand.AddComponent<Hand>();

        GameObject cardBuilder = new GameObject();
        cardBuilder.AddComponent<CardBuilder>();



        Assert.That(Hand.instance.Cards.Count, Is.EqualTo(5));
        yield return null;
    }
}
