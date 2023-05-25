using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITimerSetter : UISetter
{


    public override void Start()
    {
        functionToCall = SetterTimer;
        base.Start();
    }

    private void SetterTimer(params object[] parameters)
    {
        SetText();
    }

    private void SetText()
    {
        fillmentText.text = TimeSystem.instance.GetCurrentFullTime();
    }

    private void Update()
    {
        SetText();
    }


}
