using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateManager : MonoBehaviour
{
    public static UpdateManager instance;

    public Action OnUpdateDelegate = delegate { };
    public Action OnFixedUpdateDelegate = delegate { };

    public List<Animator> animators;

    bool isOnPause = false;

    public bool GetterPause()
    {
        return isOnPause;
    }

    private void Awake()
    {
        if (UpdateManager.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._LoadUIInventory, PauseGame);
        EventManager.SubscribeToEvent(EventNames._LoadUIGlobal, ResumeGame);
    }

    void Update()
    {
        Debug.Log(789);

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            if (GetterPause())
                EventManager.TriggerEvent(EventNames._LoadUIGlobal);
            else
                EventManager.TriggerEvent(EventNames._LoadUIInventory);
        }

        if (!isOnPause)
            OnUpdateDelegate();
    }

    void FixedUpdate()
    {

        if (!isOnPause)
            OnFixedUpdateDelegate();
    }

    void PauseGame(params object[] parameters)
    {
        isOnPause = true;

        foreach (Animator anim in animators)
        {
            anim.speed = 0;
        }

        EventManager.TriggerEvent(EventNames._GamePaused);
    }

    void ResumeGame(params object[] parameters)
    {
        isOnPause = false;

        foreach (Animator anim in animators)
        {
            anim.speed = 1;
        }

       EventManager.TriggerEvent(EventNames._GameResumed);
    }
}
