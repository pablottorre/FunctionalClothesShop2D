using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreTableManager : MonoBehaviour
{
    public List<ClothesSO> listOfClothes = new List<ClothesSO>();
    [SerializeField] private List<StoreTableSale> listOfTables = new List<StoreTableSale>();

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromTable, RemoveItemFromList);
        EventManager.SubscribeToEvent(EventNames._GameStart, SetTablesToDisplay);
        EventManager.SubscribeToEvent(EventNames._RerollItemsFromTables, SetTablesToDisplay);
    }

    private void RemoveItemFromList(params object[] parameters)
    {
        listOfClothes.Remove((ClothesSO)parameters[0]);
    }

    public void SetTablesToDisplay(params object[] parameters)
    {
        for (int i = 0; i < listOfTables.Count; i++)
        {
            listOfTables[i].SetItem(listOfClothes[Random.Range(0, listOfClothes.Count)]);
        }
    }
}
