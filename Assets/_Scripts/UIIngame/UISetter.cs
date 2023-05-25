using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UISetter : MonoBehaviour
{
    public TMP_Text fillmentText;

    public EventManager.EventReceiver functionToCall;

    public virtual void Start()
    {
        EventManager.SubscribeToEvent(EventNames._GameStart, functionToCall);
    }
}
