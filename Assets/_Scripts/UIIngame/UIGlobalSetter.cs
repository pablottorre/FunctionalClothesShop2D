using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGlobalSetter : MonoBehaviour
{
    [Header("Canvas Group")]
    [SerializeField] CanvasGroup cg;

    public void Start()
    {
        EventManager.SubscribeToEvent(EventNames._GameStart, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, StartingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, EndingSequence);
        EventManager.SubscribeToEvent(EventNames._LoadUISeller, EndingSequence);
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
}
