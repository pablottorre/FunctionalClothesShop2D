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

    [ContextMenu("TestGameStart")]
    public void testOP()
    {
        EventManager.TriggerEvent(EventNames._gameStart);
    }
    
    
    [ContextMenu("TestGameResume")]
    public void testResume()
    {
        EventManager.TriggerEvent(EventNames._gameResumed);
    }
    
    [ContextMenu("TestGamePaused")]
    public void testPause()
    {
        EventManager.TriggerEvent(EventNames._gamePaused);
    }
}
