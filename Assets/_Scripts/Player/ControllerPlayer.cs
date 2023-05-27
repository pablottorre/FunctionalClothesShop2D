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
        UpdateManager.instance.OnFixedUpdateDelegate += OnFixedUpdateDelegate;
        EventManager.SubscribeToEvent(EventNames._StartMeditating, StartedMeditating);
        EventManager.SubscribeToEvent(EventNames._StopMeditating, StopMeditating);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, PauseThePlayer);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, ResumeThePlayer);
        EventManager.SubscribeToEvent(EventNames._TriggerCoinAnimation, StartCoinAnimation);
        EventManager.SubscribeToEvent(EventNames._EndedFadeIn, ResumeThePlayer);
    }



    private void OnUpdateDelegate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (itemToBuyFromTable)
            {
                itemToBuyFromTable.GetComponentInParent<StoreTableSale>().BuyItem();
            }
            else if (canMeditate)
            {
                EventManager.TriggerEvent(EventNames._StartMeditating);
                lastMediationZone.EnableEAnimation();
                transform.position = lastMediationZone.GetterPositionToMeditate();
            }
            else if (isMeditating)
            {
                EventManager.TriggerEvent(EventNames._StopMeditating);
                lastMediationZone.EnableEAnimation();
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

    private void OnFixedUpdateDelegate()
    {
        if (canMove && !isMeditating)
        {
            _mp.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
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
            lastMediationZone = collision.gameObject.GetComponent<MeditationRug>();
            lastMediationZone.EnableEAnimation();
            canMeditate = true;
        }

        if (collision.gameObject.layer == 8)
        {
            isOnBuyingZone = true;
        }

        if (collision.gameObject.layer == 10)
        {
            EventManager.TriggerEvent(EventNames._TriggerDarkWizardDialogue);
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
            isOnBuyingZone = false;
        }
    }
}
