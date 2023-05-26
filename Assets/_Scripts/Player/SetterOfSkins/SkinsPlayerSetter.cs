using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsPlayerSetter : MonoBehaviour
{
    [Header("SpriteRenders")]
    [SerializeField] private List<SpriteRenderer> _sp = new List<SpriteRenderer>();

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._EquipItemToInventory, EquipItemsNewItem);
    }

    private void EquipItemsNewItem(params object[] parameters)
    {
        ClothesSO newClothh = (ClothesSO)parameters[0];
        _sp[(int)newClothh.typeOfClothes].sprite = newClothh.clothesSprite;
    }
}
