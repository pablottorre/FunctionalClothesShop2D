using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] GameObject spriteToMeditate;

    private void Start()
    {
        EventManager.SubscribeToEvent( EventNames._LoadUIGlobal,EnableEAnimation);
        EventManager.SubscribeToEvent( EventNames._LoadUISeller,EnableEAnimation);
    }

    public void EnableEAnimation(params object[] parameters)
    {
        if (spriteToMeditate.activeInHierarchy)
            spriteToMeditate.SetActive(false);
        else
            spriteToMeditate.SetActive(true);
    }
}
