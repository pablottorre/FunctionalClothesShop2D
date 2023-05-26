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

        SetterBoolean();
    }

    public override void BuyableSetter(bool value)
    {
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromSeller, SetterBoolean);
        EventManager.UnsuscribeToEvent(EventNames._BuySomethingFromTable, SetterBoolean);

        base.BuyableSetter(value);
        GetComponent<Button>().interactable = value;
    }
}
