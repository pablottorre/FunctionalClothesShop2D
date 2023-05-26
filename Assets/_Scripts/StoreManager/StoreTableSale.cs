using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreTableSale : ItemToBuy
{

    [SerializeField] SpriteRenderer clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;
    public int realPrice;

    [Header("Item No Longer On Sale")]
    [SerializeField] BoxCollider2D buyZone;

    public override void SetItem(ClothesSO _cloth)
    {
        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        float priceToDiscount = Random.Range(0.5f, 0.95f);
        int tempNumb = Mathf.RoundToInt(_cloth.clothesCost * priceToDiscount);
        realPrice = tempNumb;
        clothesPriceToDisplay.text = tempNumb.ToString("F0");
        _so = _cloth;
        eventName = EventNames._BuySomethingFromTable;

        SetterBoolean();
    }

    public override void SetterBoolean(params object[] parameters)
    {
        if (EconomySystem.instance.CheckIfBuyable(realPrice))
            BuyableSetter(true);
        else
            BuyableSetter(false);
    }

    public override void BuyableSetter(bool value)
    {
        base.BuyableSetter(value);
    }

    public override void BuyItem()
    {
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromSeller, SetterBoolean);
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromTable, SetterBoolean);

        if (isBuyable)
        {
            buyZone.enabled = false;
            clothesSpriteToDisplay.enabled = false;
            clothesPriceToDisplay.text = "";

            EconomySystem.instance.SpendCoins(realPrice);
            EventManager.TriggerEvent(eventName, _so);
            BuyableSetter(false);
        }    }

}
