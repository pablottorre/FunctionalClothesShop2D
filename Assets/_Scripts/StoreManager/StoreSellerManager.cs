using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreSellerManager : MonoBehaviour
{

    public List<ClothesSO> listOfClothes = new List<ClothesSO>();
    private List<GameObject> itemsFromPoolSeller;
    private List<GameObject> itemsFromPoolOwn;
    [SerializeField] private ObjectPool _opSellerItem;
    [SerializeField] private ObjectPool _opOwnItem;
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private TMP_Text dialogueText;


    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;

    [Header("Dialogue")]
    [SerializeField] List<DialoguesSO> buyingDialogues = new List<DialoguesSO>();
    [SerializeField] List<DialoguesSO> sellingDialogues = new List<DialoguesSO>();



    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._ShowItemsInStore, SetChatToDisplay);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromSeller, RemoveItemFromList);
        EventManager.SubscribeToEvent(EventNames._InvetoryUpdated, UpdatePlayerUI);
        EventManager.SubscribeToEvent(EventNames._Sellsomething, SellItems);

        EventManager.SubscribeToEvent(EventNames._LoadUISeller, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, EndingSequence);
    }

    public virtual void StartingSequence(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
        goldText.text = EconomySystem.instance.GetCurrentCoins().ToString();
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

        for (int i = 0; i < itemsFromPoolOwn.Count; i++)
        {
            itemsFromPoolOwn[i].SetActive(true);
        }

        for (int i = 0; i < InventoryManager.instance.GetterOwnedClothes().Count; i++)
        {
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterCell(InventoryManager.instance.GetterOwnedClothes()[i]);
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterForSale(true);
        }

    }

    public void RemoveItemFromList(params object[] parameters)
    {
        StopCoroutine(HideDialogue());
        listOfClothes.Remove((ClothesSO)parameters[0]);
        dialogueText.text = buyingDialogues[Random.Range(0, buyingDialogues.Count)].dialogueText;
        StartCoroutine(HideDialogue());
        UpdateGoldText();
    }

    public void UpdatePlayerUI(params object[] parameters)
    {
        if (cg.alpha == 0)
            return;

        for (int i = 0; i < InventoryManager.instance.GetterOwnedClothes().Count; i++)
        {
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterCell(InventoryManager.instance.GetterOwnedClothes()[i]);
            itemsFromPoolOwn[i].GetComponent<ItemCellSetter>().SetterForSale(true);
            itemsFromPoolOwn[i].SetActive(true);
        }
    }

    public void SellItems(params object[] parameters)
    {
        StopCoroutine(HideDialogue());
        UpdateGoldText();
        dialogueText.text = sellingDialogues[Random.Range(0, sellingDialogues.Count)].dialogueText;
        StartCoroutine(HideDialogue());
    }

    private void UpdateGoldText()
    {
        goldText.text = EconomySystem.instance.GetCurrentCoins().ToString();
    }

    IEnumerator HideDialogue()
    {
        yield return new WaitForSecondsRealtime(5);
        dialogueText.text = "";
    }
}
