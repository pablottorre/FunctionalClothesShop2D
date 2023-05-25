using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UICoinSetter : UISetter
{


    public override void Start()
    {
        functionToCall = SetterCoins;
        base.Start();
    }

    private void SetterCoins(params object[] parameters)
    {
        fillmentText.text = EconomySystem.instance.GetCurrentCoins().ToString();
    }
}
