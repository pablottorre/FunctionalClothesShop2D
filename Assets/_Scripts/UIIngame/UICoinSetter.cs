using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UICoinSetter : UISetter
{


    public override void Start()
    {
        functionToCall = SetterCoins;
        base.Start();
        EventManager.SubscribeToEvent(EventNames._BuySomething, functionToCall);
    }

    private void SetterCoins(params object[] parameters)
    {
        SetCoins();
    }

    private void SetCoins()
    {
        fillmentText.text = EconomySystem.instance.GetCurrentCoins().ToString();
    }
}
