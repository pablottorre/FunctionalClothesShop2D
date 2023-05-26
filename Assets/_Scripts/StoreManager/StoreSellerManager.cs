using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreSellerManager : StoreManager
{
    public List<GameObject> itemsFromPool;
    [SerializeField] private ObjectPool _op;


    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;


    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._ShowItemsInStore, SetChatToDisplay);

        EventManager.SubscribeToEvent(EventNames._LoadUISeller, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUISeller, EndingSequence);
    }

    public virtual void StartingSequence(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }

    public virtual void EndingSequence(params object[] parameters)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }



    [ContextMenu("xcv")]
    public void GetItemsFromPool()
    {
        itemsFromPool = _op.objectPoolCollection;
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
