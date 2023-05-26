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
    [SerializeField] GameObject spriteToBuy;

    [Header("Item No Longer On Sale")]
    [SerializeField] BoxCollider2D buyZone;

    public override void SetItem(ClothesSO _cloth)
    {
        buyZone.enabled = true;
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

    public override void BuyItem()
    {
        if (isBuyable)
        {
            DisableItemOnSale();
            EconomySystem.instance.SpendCoins(realPrice);
            EventManager.TriggerEvent(eventName, _so);
            BuyableSetter(false);
        }

    }

    public void EnableEAnimation()
    {
        if (spriteToBuy.activeInHierarchy)
            spriteToBuy.SetActive(false);
        else
            spriteToBuy.SetActive(true);
    }

    private void DisableItemOnSale()
    {
        buyZone.enabled = false;
        clothesSpriteToDisplay.sprite = null;
        clothesPriceToDisplay.text = "";
        spriteToBuy.SetActive(false);
    }
}
