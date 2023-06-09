using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreChatSale : ItemToBuy
{


    [SerializeField] Image clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesNameToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;
    [SerializeField] GameObject outOfStockGameObject;

    public override void Start()
    {
        base.Start();
        EventManager.SubscribeToEvent(EventNames._Sellsomething, SetterBoolean);
    }

    public override void SetItem(ClothesSO _cloth)
    {
        eventName = EventNames._BuySomethingFromSeller;

        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        clothesNameToDisplay.text = _cloth.clothesName;
        clothesPriceToDisplay.text = _cloth.clothesCost.ToString();
        _so = _cloth;
        SetOutOfStock(false);

        SetterBoolean();
    }

    public override void BuyableSetter(bool value)
    {
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromSeller, SetterBoolean);
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromTable, SetterBoolean);

        base.BuyableSetter(value);
        GetComponent<Button>().interactable = value;
    }

    public override void BuyItem()
    {
        if (!InventoryManager.instance.canBuyWithSpace())
        {
            EventManager.TriggerEvent(EventNames._Inventoryfull);
            return;
        }

        if (isBuyable)
        {
            EconomySystem.instance.SpendCoins(_so.clothesCost);
            EventManager.TriggerEvent(eventName, _so);
            BuyableSetter(false);
            SetOutOfStock(true);
        }
    }

    public void SetOutOfStock(bool value)
    {
        outOfStockGameObject.SetActive(value);
    }
}
