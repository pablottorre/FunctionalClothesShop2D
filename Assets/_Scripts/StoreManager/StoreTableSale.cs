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

    [Header("Offset For Items")]
    [SerializeField] private List<Vector3> offsettPosition = new List<Vector3>();

    public override void SetItem(ClothesSO _cloth)
    {
        buyZone.enabled = true;
        switch (_cloth.typeOfClothes)
        {
            case ClothesType.Hood:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[0];
                break;
            case ClothesType.Mask:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[1];
                break;
            case ClothesType.Torso:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[2];
                break; 
            case ClothesType.Pelvis:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[3];
                break;
            case ClothesType.ShoesL:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[4];
                break;
            case ClothesType.ShoesR:
                clothesSpriteToDisplay.transform.localPosition = offsettPosition[5];
                break;      
            default:
                break;
        }
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
