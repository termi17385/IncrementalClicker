using incrementalClicker.player;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    #region Clicker
    public int products;
    public float money;
    public float sellAmount;
    #endregion

    #region AutoClickers
    public bool autoSeller;
    public bool autoClicker;
    
    public int sellers;
    public int robots;
    
    public float sellerCost;
    public float sellerCostIncrease;

    public float clickerCost;
    public float clickerCostIncrease;
    #endregion

    #region Experience
    public float playerXP;
    public int playerLevel;
    #endregion


    public PlayerData()
    {
        #region Saving PlayerStats
        products = PlayerStats.products;
        money = PlayerStats.money;
        sellAmount = PlayerStats.sellAmount;

        autoClicker = PlayerStats.autoClickSave;
        autoSeller = PlayerStats.autoSellSave;
        #endregion

        #region AutoClickers
        sellers = AutoSeller.autoClick;
        robots = AutoClicker.autoClick;

        clickerCost = ClickerButton.cost;
        clickerCostIncrease = ClickerButton.costIncrease;

        sellerCost = SellerButton.cost;
        sellerCostIncrease = SellerButton.costIncrease;
        #endregion

        #region Experience
        playerXP = PlayerStats.xp;
        playerLevel = PlayerStats.level;
        #endregion


    }

}
