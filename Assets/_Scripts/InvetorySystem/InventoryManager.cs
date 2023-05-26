using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    public List<ClothesSO> clothesOwned = new List<ClothesSO>();
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
    }

    public List<ClothesSO> GetterOwnedClothes()
    {
        return clothesOwned;
    }
    
    public List<ClothesSO> GetterEquipedClothes()
    {
        return clothesEquiped;
    }

    public void AddItemToInventory(params object[] parameters)
    {

        clothesOwned.Add((ClothesSO)parameters[0]);
    }
}
