using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonMM : MonoBehaviour
{
    [SerializeField] private string sceneName;


    private void Start()
    {
        EventManager.SubscribeToEvent(EventNames._gameStart, LoadSceneToPlay);
    }


    public void LoadSceneToPlay(params object[] parameters)
    {
        SceneManager.LoadScene(sceneName);
    }
}
