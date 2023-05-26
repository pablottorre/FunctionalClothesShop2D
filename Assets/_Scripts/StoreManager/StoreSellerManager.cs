using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSellerManager : MonoBehaviour
{

    public List<ClothesSO> listOfClothes = new List<ClothesSO>();
    private List<GameObject> itemsFromPoolSeller;
    private List<GameObject> itemsFromPoolOwn;
    [SerializeField] private ObjectPool _opSellerItem;
    [SerializeField] private ObjectPool _opOwnItem;


    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;


    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._ShowItemsInStore, SetChatToDisplay);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromSeller, RemoveItemFromList);

        EventManager.SubscribeToEvent(EventNames._LoadUISeller, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, EndingSequence);
    }

    public virtual void StartingSequence(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        GetItemsFromPool();
    }

    public virtual void EndingSequence(params object[] parameters)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    public void GetItemsFromPool()
    {
        itemsFromPoolSeller = _opSellerItem.objectPoolCollection;
        itemsFromPoolOwn = _opOwnItem.objectPoolCollection;
        SetChatToDisplay();
    }


    public void SetChatToDisplay(params object[] parameters)
    {
        for (int i = 0; i < listOfClothes.Count; i++)
        {
            itemsFromPoolSeller[i].GetComponent<StoreChatSale>().SetItem(listOfClothes[i]);
            itemsFromPoolSeller[i].SetActive(true);
        }

        for (int i = 0; i < InventoryManager.instance.GetterOwnedClothes().Count; i++)
        {
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterCell(InventoryManager.instance.GetterOwnedClothes()[i]);
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterForSale(true);
            itemsFromPoolOwn[i].SetActive(true);
        }

        for (int i = 0; i < itemsFromPoolOwn.Count; i++)
        {
            itemsFromPoolOwn[i].SetActive(true);
        }
    }

    public void RemoveItemFromList(params object[] parameters)
    {
        listOfClothes.Remove((ClothesSO)parameters[0]);
    }
}
