using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCellSetter : MonoBehaviour
{
    private ClothesSO so;
    [SerializeField] private Image sprite;

    public void SetterCell(ClothesSO _value)
    {
        sprite.sprite = _value.clothesSprite;
    }
}
