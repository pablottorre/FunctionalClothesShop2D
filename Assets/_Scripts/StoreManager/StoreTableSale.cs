using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreTableSale : MonoBehaviour
{
    [SerializeField] SpriteRenderer clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;

    public void SetTable(ClothesSO _cloth)
    {
        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        clothesPriceToDisplay.text = _cloth.clothesCost.ToString();
    }
}
