using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] GameObject notificationFullInv;
    [SerializeField] float notificationTimer;

    private void Start()
    {
        StartCoroutine(LateStart());
        EventManager.SubscribeToEvent(EventNames._Inventoryfull, NotifyFullInventory);
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.15f);
        EventManager.TriggerEvent(EventNames._GameStart);
        TimeSystem.instance.KeepCountingTime();
    }

    private void NotifyFullInventory(params object[] parameters)
    {
        notificationFullInv.SetActive(true);
        StartCoroutine(WaitForDesactivateNotification());
    }

    IEnumerator WaitForDesactivateNotification()
    {
        yield return new WaitForSecondsRealtime(notificationTimer);
        notificationFullInv.SetActive(false);
    }
}
