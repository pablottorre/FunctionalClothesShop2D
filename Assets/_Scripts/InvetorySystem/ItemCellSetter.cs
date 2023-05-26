using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellSetter : MonoBehaviour
{
    [SerializeField] private Image sprite;
    private bool isInUse = false;
    [SerializeField] private bool isExclusive = false;
    [SerializeField] private ClothesType typeToUse;

    public void SetterCell(ClothesSO _value)
    {
        sprite.sprite = _value.clothesSprite;
        isInUse = true;
    }

    public bool GettterInUse()
    {
        return isInUse;
    }
}
