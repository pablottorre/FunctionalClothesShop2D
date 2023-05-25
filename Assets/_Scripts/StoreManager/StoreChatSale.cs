using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreChatSale : MonoBehaviour
{
    [SerializeField] Image clothesSpriteToDisplay;
    [SerializeField] TMP_Text clothesNameToDisplay;
    [SerializeField] TMP_Text clothesPriceToDisplay;

    public void SetChatSale(ClothesSO _cloth)
    {
        clothesSpriteToDisplay.sprite = _cloth.clothesSprite;
        clothesNameToDisplay.text = _cloth.clothesName;
        clothesPriceToDisplay.text = _cloth.clothesCost.ToString();
    }
}
