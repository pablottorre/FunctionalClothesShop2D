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



    public override void SetItem(ClothesSO _cloth)
    {
        eventName = EventNames._BuySomethingFromSeller;

        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        clothesNameToDisplay.text = _cloth.clothesName;
        clothesPriceToDisplay.text = _cloth.clothesCost.ToString();
        _so = _cloth;

        if (_so.clothesCost <= EconomySystem.instance.GetCurrentCoins())
            BuyableSetter(true);
        else
            BuyableSetter(false);
    }

    public override void BuyableSetter(bool value)
    {
        base.BuyableSetter(value);
        GetComponent<Button>().interactable = value;
    }
}
