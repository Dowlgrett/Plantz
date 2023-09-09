using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class CardTests : InputTestFixture
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

    public override void Setup()
    {
        base.Setup();
        SceneManager.LoadScene("Assets/Scenes/Main.unity");
    }

    [UnityTest]
    public IEnumerator Clicking_Card_Selects_It()
    {
        var handPanel = GameObject.Find("HandPanel");
        var card = handPanel.transform.GetChild(0);

        var mouse = InputSystem.AddDevice<Mouse>();

        Camera camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        Vector3 screenPos = camera.WorldToScreenPoint(card.transform.position);
        Set(mouse.position, screenPos);
        Click(mouse.leftButton);

        yield return new WaitForSeconds(0.1f);

        Assert.That(EventSystem.current.currentSelectedGameObject, Is.EqualTo(card.gameObject));
    }
}


