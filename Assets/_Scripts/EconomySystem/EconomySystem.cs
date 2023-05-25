using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EconomySystem : MonoBehaviour
{
    public static EconomySystem instance;

    [SerializeField] private int currentCoins;

    private void Awake()
    {
        if (EconomySystem.instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentCoins()
    {
        return currentCoins;
    }

    public void SpendCoins(int cost)
    {
        currentCoins -= cost;
    }

    public bool CheckIfBuyable(int cost)
    {
        if (cost <= currentCoins)
            return true;
        else
            return false;
    }

    public void AddCoins(int value)
    {
        currentCoins += value;
    }
}
