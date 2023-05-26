using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreChatSale : MonoBehaviour
{
    ClothesSO _so;

    [SerializeField] Image clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesNameToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;

    private bool isBuyable;

    public ClothesSO GetterSO()
    {
        return _so;
    }

    public void SetChatSale(ClothesSO _cloth)
    {
        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        clothesNameToDisplay.text = _cloth.clothesName;
        clothesPriceToDisplay.text = _cloth.clothesCost.ToString();
        _so = _cloth;

        if (_so.clothesCost <= EconomySystem.instance.GetCurrentCoins())
            BuyableSetter(true);
        else
            BuyableSetter(false);

    }

    private void BuyableSetter(bool value)
    {

        GetComponent<Button>().interactable = value;
        isBuyable = value;
    }

    public void BuyItem()
    {
        if (isBuyable)
        {
            EventManager.TriggerEvent(EventNames._BuySomethingFromSeller, _so);
            BuyableSetter(false);
        }
    }
}
