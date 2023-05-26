using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public static TimeSystem instance;
    bool startCounting;
    float minutes;
    float hours = 8;


    private void Awake()
    {
        if (TimeSystem.instance == null)
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
        UpdateManager.instance.OnUpdateDelegate += OnUpdateDelegate;
        EventManager.SubscribeToEvent(EventNames._GameResumed, KeepCountingTime);
        EventManager.SubscribeToEvent(EventNames._GameStart, KeepCountingTime);
        EventManager.SubscribeToEvent(EventNames._GamePaused, StopCountingTime);
    }

    private void OnUpdateDelegate()
    {
        if (startCounting )
        {
            minutes += Time.deltaTime;
            if (minutes > 59)
            {
                minutes = 0;
                EventManager.TriggerEvent(EventNames._RerollItemsFromTables);
                hours++;
                if (hours > 24)
                    hours = 0;

            }
        }
    }

    public string GetCurrentFullTime()
    {
        return hours.ToString("F0") + ":" + minutes.ToString("F0");
    }
        
    public void KeepCountingTime(params object[] parameters)
    {
        startCounting = true;
    }

    private void StopCountingTime(params object[] parameters)
    {
        startCounting = false;
    }
}
