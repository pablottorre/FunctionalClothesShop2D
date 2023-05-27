using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [Header("Object Pool")]
    [SerializeField] ObjectPool _op;
    public List<ClothesSO> clothesOwned = new List<ClothesSO>();
    public List<ClothesSO> clothesEquiped = new List<ClothesSO>();
    [SerializeField] private List<GameObject> gridEquipment = new List<GameObject>();

    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;

    [Header("Coins")]
    [SerializeField] private TMP_Text coinsText;

    private ClothesSO selectedSO;
    private GameObject currentCell;

    public void Start()
    {
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUISeller, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._SelectItemOnInvetory, SelectItemOnInventory);
        EventManager.SubscribeToEvent(EventNames._SelectItemFromInvetory, SelectItemFromInventory);
        EventManager.SubscribeToEvent(EventNames._EquipItemToInventory, UpdateInventoryAfterEquip);
        EventManager.SubscribeToEvent(EventNames._UnequipItemFromInvetory, UpdateInventoryAfterUnequip);
    }

    public virtual void StartingSequence(params object[] parameters)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;

        for (int i = 0; i < _op.objectPoolCollection.Count; i++)
        {
            _op.objectPoolCollection[i].SetActive(true);
        }

        clothesEquiped = InventoryManager.instance.GetterEquipedClothes();
        clothesOwned = InventoryManager.instance.GetterOwnedClothes();

        UpdateCoins();

        SetClothesOnInventory();
    }

    private void UpdateCoins()
    {
        coinsText.text = EconomySystem.instance.GetCurrentCoins().ToString();
    }

    public virtual void EndingSequence(params object[] parameters)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;

        for (int i = 0; i < _op.objectPoolCollection.Count; i++)
        {
            _op.objectPoolCollection[i].GetComponent<ItemCellSetter>().ResetCell();
            _op.objectPoolCollection[i].SetActive(false);
        }

        for (int i = 0; i < gridEquipment.Count; i++)
        {
            gridEquipment[i].GetComponent<ItemCellSetter>().ResetCell();
            gridEquipment[i].SetActive(false);
        }
    }
    private void SetClothesOnInventory()
    {
        for (int i = 0; i < clothesOwned.Count; i++)
        {
            _op.objectPoolCollection[i].GetComponent<ItemCellSetter>().SetterCell(clothesOwned[i]);
        }

        for (int i = 0; i < gridEquipment.Count; i++)
        {
            gridEquipment[i].SetActive(true);
        }

        for (int i = 0; i < clothesEquiped.Count; i++)
        {
            gridEquipment[(int)clothesEquiped[i].typeOfClothes].GetComponent<ItemCellSetter>().SetterCell(clothesEquiped[i]);
        }
    }

    private void UpdateInventoryAfterEquip(params object[] parameters)
    {
        clothesEquiped.Add((ClothesSO)parameters[0]);
        gridEquipment[(int)clothesEquiped[clothesEquiped.Count - 1].typeOfClothes].GetComponent<ItemCellSetter>().SetterCell(clothesEquiped[clothesEquiped.Count - 1]);
        currentCell.GetComponent<ItemCellSetter>().ResetCell();
        currentCell = null;
        clothesOwned.Remove((ClothesSO)parameters[0]);
    }

    private void UpdateInventoryAfterUnequip(params object[] parameters)
    {
        clothesOwned.Add(selectedSO);
        currentCell.GetComponent<ItemCellSetter>().ResetCell();
        clothesEquiped.Remove(selectedSO);
        selectedSO = null;
        currentCell = null;
    }

    private void SelectItemOnInventory(params object[] parameters)
    {
        selectedSO = (ClothesSO)parameters[0];
        currentCell = (GameObject)parameters[1];
        if (!gridEquipment.Contains(currentCell))
        {
            for (int i = 0; i < gridEquipment.Count; i++)
            {
                if (!gridEquipment[i].GetComponent<ItemCellSetter>().GettterInUse())
                {
                    if (gridEquipment[i].GetComponent<ItemCellSetter>().GetterType() != selectedSO.typeOfClothes)
                        gridEquipment[i].GetComponent<ItemCellSetter>().SetterAvailable(false);
                    else
                        gridEquipment[i].GetComponent<ItemCellSetter>().SetterAvailable(true);
                }
            }
        }
    }

    private void SelectItemFromInventory(params object[] parameters)
    {
        selectedSO = (ClothesSO)parameters[0];
        currentCell = (GameObject)parameters[1];
        for (int i = 0; i < _op.objectPoolCollection.Count; i++)
        {
            if (_op.objectPoolCollection[i].GetComponent<ItemCellSetter>().GettterInUse())
                _op.objectPoolCollection[i].GetComponent<ItemCellSetter>().SetterAvailable(false);
            else
                _op.objectPoolCollection[i].GetComponent<ItemCellSetter>().SetterAvailable(true);
        }
    }


}
