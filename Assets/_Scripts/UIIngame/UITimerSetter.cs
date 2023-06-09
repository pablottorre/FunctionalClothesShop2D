using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimerSetter : UISetter
{


    public override void Start()
    {
        functionToCall = SetterTimer;
        base.Start();
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, functionToCall);
        EventManager.SubscribeToEvent(EventNames._GameStart, functionToCall);
    }

    private void SetterTimer(params object[] parameters)
    {
        SetText();
    }

    private void SetText()
    {
        fillmentText.text = TimeSystem.instance.GetCurrentFullTimeInversed();
    }

    private void OnUpdateDelegate()
    {
        SetText();
    }
}
