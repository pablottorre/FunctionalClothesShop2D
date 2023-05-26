using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellSetter : MonoBehaviour
{
    ClothesSO _so;

    [SerializeField] private Image backgroundSprite;
    [SerializeField] private Image sprite;
    private bool isInUse = false;
    private bool isForSale = false;
    [SerializeField] private bool isExclusive = false;
    [SerializeField] private ClothesType typeToUse;

    public void SetterCell(ClothesSO _value)
    {
        sprite.sprite = _value.clothesSprite;
        isInUse = true;
        _so = _value;
    }

    public void SetterForSale(bool value)
    {
        isForSale = value;
    }

    public bool GettterInUse()
    {
        return isInUse;
    }

    public ClothesType GetterType()
    {
        return typeToUse;
    }

    public void SetterAvailable(bool value)
    {
        backgroundSprite.enabled = true;
        if (value)
        {
            backgroundSprite.color = Color.green;
        }
        else
        {
            backgroundSprite.color = Color.red;
        }
    }

    public void PressTheButton()
    {
        if (isForSale)
        {
            EconomySystem.instance.AddCoins(Mathf.RoundToInt(_so.clothesCost * 0.9f));
            EventManager.TriggerEvent(EventNames._Sellsomething, _so);
            sprite.sprite = null;
            EventManager.TriggerEvent(EventNames._UpdateCoins);
        }
        else
        {
            EventManager.TriggerEvent(EventNames._SelectItemOnInvetory, _so);
        }
    }
}
