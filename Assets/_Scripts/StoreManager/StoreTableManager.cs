using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTableManager : MonoBehaviour
{
    public List<ClothesSO> listOfClothes = new List<ClothesSO>();
    [SerializeField] private List<StoreTableSale> listOfTables = new List<StoreTableSale>();

    [ContextMenu("hola")]
    public void SetTablesToDisplay()
    {
        for (int i = 0; i < listOfTables.Count; i++)
        {
            listOfTables[i].SetItem(listOfClothes[Random.Range(0, listOfClothes.Count)]);
        }
    }
}
