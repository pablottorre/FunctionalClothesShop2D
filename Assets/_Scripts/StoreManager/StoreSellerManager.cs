using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSellerManager : StoreManager
{
    public List<GameObject> itemsFromPool;


    private void Start()
    {
        Debug.Log(423);
        EventManager.SubscribeToEvent(EventNames._FinishedCreatingItemsPO, GetItemsFromPool);
        EventManager.SubscribeToEvent(EventNames._ShowItemsInStore, SetChatToDisplay);
    }

    public void GetItemsFromPool(params object[] parameters)
    {
        Debug.Log(345);
        itemsFromPool = (List<GameObject>)parameters[0];
        SetChatToDisplay();
    }

    public void SetChatToDisplay(params object[] parameters)
    {
        for (int i = 0; i < listOfClothes.Count; i++)
        {
            itemsFromPool[i].GetComponent<StoreChatSale>().SetChatSale(listOfClothes[i]);
            itemsFromPool[i].SetActive(true);
        }
    }
}
