using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralManager : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(LateStart());
    }

    IEnumerator LateStart()
    {
        yield return new WaitForSeconds(0.15f);
        EventManager.TriggerEvent(EventNames._GameStart);
        TimeSystem.instance.KeepCountingTime();
    }
}
