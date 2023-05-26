using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<ClothesSO> clothesOwned = new List<ClothesSO>();
    private int maxItemsOnInvetory = 21;
    public List<ClothesSO> clothesEquiped = new List<ClothesSO>();

    private void Awake()
    {
        if (UpdateManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromSeller, AddItemToInventory);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromTable, AddItemToInventory);
        EventManager.SubscribeToEvent(EventNames._Sellsomething, RemoveItemToInventory);
    }

    public List<ClothesSO> GetterOwnedClothes()
    {
        return clothesOwned;
    }

    public bool canBuyWithSpace()
    {
        return clothesOwned.Count < maxItemsOnInvetory;
    }
    
    public List<ClothesSO> GetterEquipedClothes()
    {
        return clothesEquiped;
    }

    public void AddItemToInventory(params object[] parameters)
    {
        clothesOwned.Add((ClothesSO)parameters[0]);
        EventManager.TriggerEvent(EventNames._InvetoryUpdated);
    }

    public void RemoveItemToInventory(params object[] parameters)
    {
        clothesOwned.Remove((ClothesSO)parameters[0]);
    }
}
