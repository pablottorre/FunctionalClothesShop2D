using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [Header("PlayerModel")]
    [SerializeField] ModelPlayer _mp;


    void Start()
    {
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
    }



    private void OnUpdateDelegate()
    {
        _mp.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponentInParent<StoreTableSale>().BuyItem();
        }
    }
}
