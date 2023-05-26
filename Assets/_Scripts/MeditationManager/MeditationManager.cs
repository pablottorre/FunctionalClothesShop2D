using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationManager : MonoBehaviour
{
    private bool isMeditating = false;

    void Start()
    {
        EventManager.SubscribeToEvent(EventNames._StartMeditating, StartMeditating);
        EventManager.SubscribeToEvent(EventNames._StopMeditating, StopMeditating);
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
    }

    private void StartMeditating(params object[] parameters)
    {
        isMeditating = true;
        StartCoroutine(MeditatingCorutine());
    }

    private void StopMeditating(params object[] parameters)
    {
        isMeditating = false;
    }

    IEnumerator MeditatingCorutine()
    {
        while (isMeditating)
        {
            yield return new WaitForSecondsRealtime(1);
            EconomySystem.instance.AddCoins(5);
            EventManager.TriggerEvent(EventNames._UpdateCoins);
        }
    }

    private void OnUpdateDelegate()
    {
        if (isMeditating)
        {

        }
    }
}