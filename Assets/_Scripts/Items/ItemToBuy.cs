using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToBuy : MonoBehaviour
{
    [HideInInspector]public ClothesSO _so;

    public bool isBuyable;

    [HideInInspector] public string eventName;

    public ClothesSO GetterSO()
    {
        return _so;
    }

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromSeller,SetterBoolean);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromTable,SetterBoolean);
    }

    public virtual void SetItem(ClothesSO _cloth)
    {

    }

    public virtual void SetterBoolean(params object[] parameters)
    {
        if (EconomySystem.instance.CheckIfBuyable(_so.clothesCost))
            BuyableSetter(true);
        else
            BuyableSetter(false);
    }

    public virtual void BuyableSetter(bool value)
    {
        isBuyable = value;
    }

    public virtual void BuyItem()
    {
        if (isBuyable)
        {
            EconomySystem.instance.SpendCoins(_so.clothesCost);
            EventManager.TriggerEvent(eventName, _so);
            BuyableSetter(false);
        }
    }
}
