using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    public void HasEnded()
    {
        gameObject.SetActive(false);
    }
}
