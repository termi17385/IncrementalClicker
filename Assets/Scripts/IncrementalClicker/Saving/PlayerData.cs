using incrementalClicker.manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int products;
    public float money;
    public float sellAmount;

    public int autoSeller;
    public int autoClicker;
    public int sellers;
    public int robots;

    
    public PlayerData()
    {
        products = GameManager.production;
        money = GameManager.cashCount;
        sellAmount = GameManager.sellAmount;

        autoClicker = GameManager.autoClick;
        autoSeller = GameManager.autoSell;

        sellers = AutoSeller.autoClick;
        robots = AutoClicker.autoClick;


    }

}
