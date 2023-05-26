using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    [SerializeField] GameObject spriteToMeditate;

    public void EnableEAnimation()
    {
        if (spriteToMeditate.activeInHierarchy)
            spriteToMeditate.SetActive(false);
        else
            spriteToMeditate.SetActive(true);
    }
}
