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

        BuyableSetter();

    }

    private void BuyableSetter()
    {
        Debug.Log(EconomySystem.instance.GetCurrentCoins());
        if (_so.clothesCost <= EconomySystem.instance.GetCurrentCoins())
        {
            isBuyable = true;
        }
        else
        {
            isBuyable = false;
        }
    }

    public void BuyItem()
    {
        if (isBuyable)
        {
        Debug.Log("456");
            EventManager.TriggerEvent(EventNames._BuySomethingFromSeller, this.gameObject);
        }
    }
}
