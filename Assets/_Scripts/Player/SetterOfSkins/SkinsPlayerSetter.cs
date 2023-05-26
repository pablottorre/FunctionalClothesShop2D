using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayerSetter : MonoBehaviour
{
    [Header("SpriteRenders")]
    [SerializeField] private List<SpriteRenderer> _sp = new List<SpriteRenderer>();

    [Header("Original Clothes")]
    [SerializeField] private List<ClothesSO> ogClothes = new List<ClothesSO>();

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._EquipItemToInventory, EquipItemsNewItem);
        EventManager.SubscribeToEvent(EventNames._UnequipItemFromInvetory, UnequipItem);
    }

    private void EquipItemsNewItem(params object[] parameters)
    {
        ClothesSO newClothh = (ClothesSO)parameters[0];
        _sp[(int)newClothh.typeOfClothes].sprite = newClothh.clothesSprite;
    }

    private void UnequipItem(params object[] parameters)
    {
        ClothesSO newClothh = (ClothesSO)parameters[0];
        _sp[(int)newClothh.typeOfClothes].sprite = ogClothes[(int)newClothh.typeOfClothes].clothesSprite;
    }
}
