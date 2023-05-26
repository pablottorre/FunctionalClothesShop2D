using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem : MonoBehaviour
{
    public static TimeSystem instance;
    bool startCounting;
    float minutes;
    [SerializeField] private float maxTimer;


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
            if (minutes > maxTimer)
            {
                minutes = 0;
                EventManager.TriggerEvent(EventNames._RerollItemsFromTables);
            }
        }
    }

    public string GetCurrentFullTime()
    {
        return minutes.ToString("F0");
    }
    
    public string GetCurrentFullTimeInversed()
    {
        return (maxTimer - minutes).ToString("F0");
    } 
    
    public float GetCurrentMinutesTime()
    {
        return minutes;
    }

    public float GetterMaxTimer()
    {
        return maxTimer;
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
