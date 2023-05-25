using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsFunctions : MonoBehaviour
{
    public void PlayButtonFunction()
    {
        EventManager.TriggerEvent("");
    }

    public void OptionsButtonFunction()
    {

    }

    public void ExitButtonFunction()
    {
        Application.Quit();
    }
}
