using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(menuName = "Clothes")]
public class ClothesSO : ScriptableObject
{
    [Header("Sprite")]
    public Sprite clothesSprite;

    [Header("Cost")]
    public int clothesCost;

    [Header("Name")]
    public string clothesName;

    [Header("Type")]
    public ClothesType typeOfClothes;
}

public enum ClothesType
{
    Hood,
    Mask,
    Torso,
    Pelvis,
    ShoesL,
    ShoesR
}
