using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    public void PlayButtonFunction()
    {
        EventManager.TriggerEvent(EventNames._gameStart);
    }

    public void OptionsButtonFunction()
    {
        EventManager.TriggerEvent(EventNames._optionsStart);
    }

    public void ExitButtonFunction()
    {
        Application.Quit();
    }
}
