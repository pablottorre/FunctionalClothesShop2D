using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToBuy : MonoBehaviour
{
    [HideInInspector]public ClothesSO _so;

    [HideInInspector] public bool isBuyable;

    [HideInInspector] public string eventName;

    public ClothesSO GetterSO()
    {
        return _so;
    }

    public virtual void SetItem(ClothesSO _cloth)
    {

    }

    public virtual void BuyableSetter(bool value)
    {
        isBuyable = value;
    }

    public virtual void BuyItem()
    {
        if (isBuyable)
        {
            EventManager.TriggerEvent(eventName, _so);
            BuyableSetter(false);
        }
    }
}
