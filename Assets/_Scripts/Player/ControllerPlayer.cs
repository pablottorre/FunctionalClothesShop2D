using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [Header("PlayerModel")]
    [SerializeField] ModelPlayer _mp;

    private GameObject itemToBuyFromTable;


    void Start()
    {
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
    }



    private void OnUpdateDelegate()
    {
        _mp.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (itemToBuyFromTable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                itemToBuyFromTable.GetComponentInParent<StoreTableSale>().BuyItem();
            }
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            itemToBuyFromTable = collision.gameObject;

        }
    }
}
