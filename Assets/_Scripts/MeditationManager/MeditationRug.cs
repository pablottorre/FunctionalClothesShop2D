using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeditationRug : MonoBehaviour
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
