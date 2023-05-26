using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [Header("PlayerModel")]
    [SerializeField] ModelPlayer _mp;

    private GameObject itemToBuyFromTable;

    private bool canMeditate;
    private bool isMeditating;
    private bool canMove;

    private bool isOnBuyingZone;
    private bool isOnBuyingMenu;

    [Header("CoinAnimation")]
    [SerializeField] private GameObject animationCoin;
    private MeditationRug lastMediationZone;



    void Start()
    {
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
        EventManager.SubscribeToEvent(EventNames._GameStart, ResumeThePlayer);
        EventManager.SubscribeToEvent(EventNames._StartMeditating, StartedMeditating);
        EventManager.SubscribeToEvent(EventNames._StopMeditating, StopMeditating);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, PauseThePlayer);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, ResumeThePlayer);
        EventManager.SubscribeToEvent(EventNames._TriggerCoinAnimation, StartCoinAnimation);
    }



    private void OnUpdateDelegate()
    {
        if (canMove && !isMeditating)
        {
            _mp.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemToBuyFromTable)
            {
                itemToBuyFromTable.GetComponentInParent<StoreTableSale>().BuyItem();
            }
            else if (canMeditate)
            {
                EventManager.TriggerEvent(EventNames._StartMeditating);
                transform.position = lastMediationZone.GetterPositionToMeditate();
            }
            else if (isMeditating)
            {
                EventManager.TriggerEvent(EventNames._StopMeditating);
            }
            else if (isOnBuyingZone)
            {
                if (isOnBuyingMenu)
                {
                    EventManager.TriggerEvent(EventNames._LoadUIGlobal);
                    isOnBuyingMenu = false;
                }
                else
                {
                    isOnBuyingMenu = true;
                    EventManager.TriggerEvent(EventNames._LoadUISeller);
                }
            }
        }
    }

    private void PauseThePlayer(params object[] parameters)
    {
        canMove = false;
    }

    private void ResumeThePlayer(params object[] parameters)
    {
        canMove = true;
    }

    private void StartedMeditating(params object[] parameters)
    {
        canMeditate = false;
        isMeditating = true;
        canMove = false;
    }

    private void StopMeditating(params object[] parameters)
    {
        canMeditate = true;
        isMeditating = false;
        canMove = true;
    }

    private void StartCoinAnimation(params object[] parameters)
    {
        animationCoin.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            itemToBuyFromTable = collision.gameObject;
            itemToBuyFromTable.GetComponentInParent<StoreTableSale>().EnableEAnimation();
        }

        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<MeditationRug>().EnableEAnimation();
            lastMediationZone = collision.gameObject.GetComponent<MeditationRug>();
            canMeditate = true;
        }

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<CounterManager>().EnableEAnimation();
            isOnBuyingZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            itemToBuyFromTable.GetComponentInParent<StoreTableSale>().EnableEAnimation();
            itemToBuyFromTable = null;
        }

        if (collision.gameObject.layer == 7)
        {
            collision.gameObject.GetComponent<MeditationRug>().EnableEAnimation();
            canMeditate = false;
            lastMediationZone = null;
        }

        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<CounterManager>().EnableEAnimation();
            isOnBuyingZone = false;
        }
    }
}
