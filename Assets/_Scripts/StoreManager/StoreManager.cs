using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private List<ClothesSO> listOfClothes = new List<ClothesSO>();
    [SerializeField] private List<StoreTableSale> listOfTables = new List<StoreTableSale>();

    [ContextMenu("TestTables")]
    public void SetTablesToDisplay()
    {
        for (int i = 0; i < listOfTables.Count; i++)
        {
            listOfTables[i].SetTable(listOfClothes[Random.Range(0, listOfClothes.Count)]);
        }
    }
}
