using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreTableSale : ItemToBuy
{

    [SerializeField] SpriteRenderer clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;

    [Header("Item No Longer On Sale")]
    [SerializeField] BoxCollider2D buyZone;

    public override void SetItem(ClothesSO _cloth)
    {
        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        float priceToDiscount = Random.Range(0.5f, 0.95f);
        clothesPriceToDisplay.text = (_cloth.clothesCost * priceToDiscount).ToString("F0");
        _so = _cloth;
        eventName = EventNames._BuySomethingFromTable;

        if (_so.clothesCost <= EconomySystem.instance.GetCurrentCoins())
            BuyableSetter(true);
        else
            BuyableSetter(false);
    }

    public override void BuyableSetter(bool value)
    {
        base.BuyableSetter(value);
        //GetComponent<Button>().interactable = value;
    }

    public override void BuyItem()
    {
        base.BuyItem();
        buyZone.enabled = false;
        clothesSpriteToDisplay.enabled = false;
        clothesPriceToDisplay.text = "";

    }

}
