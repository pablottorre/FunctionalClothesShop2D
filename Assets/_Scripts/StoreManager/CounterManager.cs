using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] GameObject spriteToMeditate;
    bool isPlayerOnZone;

    private void Start()
    {
        EventManager.SubscribeToEvent( EventNames._LoadUIGlobal,EnableEAnimation);
        EventManager.SubscribeToEvent( EventNames._LoadUISeller, DisableEAnimation);
    }

    public void EnableEAnimation(params object[] parameters)
    {
        if (isPlayerOnZone)
            spriteToMeditate.SetActive(true);
        else
            spriteToMeditate.SetActive(false);
    }
    
    public void DisableEAnimation(params object[] parameters)
    {
            spriteToMeditate.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isPlayerOnZone = true;
            EnableEAnimation();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            isPlayerOnZone = false;
            EnableEAnimation();
        }
    }
}
