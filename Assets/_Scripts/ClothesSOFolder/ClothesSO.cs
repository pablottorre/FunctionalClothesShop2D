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
}
