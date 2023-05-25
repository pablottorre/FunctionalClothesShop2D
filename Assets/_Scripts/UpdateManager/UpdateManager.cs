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
        EventManager.SubscribeToEvent("PauseGame", PauseGame);
        EventManager.SubscribeToEvent("ResumeGame", ResumeGame);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOnPause)
                EventManager.TriggerEvent("ResumeGame");
            else
                EventManager.TriggerEvent("PauseGame");
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

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        foreach (Animator anim in animators)
        {
            anim.speed = 0;
        }
    }

    void ResumeGame(params object[] parameters)
    {
        isOnPause = false;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        foreach (Animator anim in animators)
        {
            anim.speed = 1;
        }
    }
}
