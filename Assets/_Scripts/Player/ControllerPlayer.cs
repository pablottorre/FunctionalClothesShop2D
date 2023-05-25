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
        EventManager.TriggerEvent(EventNames._GameStart);
    }
    
    
    [ContextMenu("TestGameResume")]
    public void testResume()
    {
        EventManager.TriggerEvent(EventNames._GameResumed);
    } 
    
   /* [ContextMenu("TestOP")]
    public void testOP()
    {
        EventManager.TriggerEvent(EventNames.ob);
    }*/
    
    [ContextMenu("TestGameResume345")]
    public void testResume34534()
    {
        EventManager.TriggerEvent(EventNames._PlayerEnterTheStore);
    }
    
    [ContextMenu("TestGamePaused")]
    public void testPause()
    {
        EventManager.TriggerEvent(EventNames._GamePaused);
    }
    
    
    [ContextMenu("TestStartMeditating")]
    public void testStartMeditating()
    {
        EventManager.TriggerEvent(EventNames._StartMeditating);
    }
    
    [ContextMenu("TestStopMeditating")]
    public void testStopMeditating()
    {
        EventManager.TriggerEvent(EventNames._StopMeditating);
    }
}
