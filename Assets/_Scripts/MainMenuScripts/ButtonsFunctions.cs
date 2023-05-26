using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    public void PlayButtonFunction()
    {
        EventManager.TriggerEvent(EventNames._GameStartButton);
    }
    public void ExitButtonFunction()
    {
        Application.Quit();
    }
}
