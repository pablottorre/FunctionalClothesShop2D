using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTableManager : StoreManager
{

    [SerializeField] private List<StoreTableSale> listOfTables = new List<StoreTableSale>();

    public void SetTablesToDisplay()
    {
        for (int i = 0; i < listOfTables.Count; i++)
        {
            listOfTables[i].SetTable(listOfClothes[Random.Range(0, listOfClothes.Count)]);
        }
    }
}
