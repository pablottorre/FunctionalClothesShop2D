using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    [Header("Object Pool")]
    [SerializeField] ObjectPool _op;
    public List<ClothesSO> clothesOwned = new List<ClothesSO>();
    public List<ClothesSO> clothesEquiped = new List<ClothesSO>();
    [SerializeField] private List<GameObject> gridEquipment = new List<GameObject>();

    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;

    public static InventorySystem instance;

    private void Awake()
    {
        if (InventorySystem.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUISeller, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromSeller, AddItemToInventory);
        EventManager.SubscribeToEvent(EventNames._BuySomethingFromTable, AddItemToInventory);
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

    [ContextMenu("SetCellsOnInventory")]
    private void SetClothesOnInventory()
    {
        for (int i = 0; i < clothesOwned.Count; i++)
        {
            _op.objectPoolCollection[i].GetComponent<ItemCellSetter>().SetterCell(clothesOwned[i]);
        }

        for (int i = 0; i < clothesEquiped.Count; i++)
        {
            gridEquipment[i].GetComponent<ItemCellSetter>().SetterCell(clothesEquiped[i]);
        }
    }

    public void AddItemToInventory(params object[] parameters)
    {

        clothesOwned.Add((ClothesSO)parameters[0]);
    }
}
