using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using incrementalClicker.manager;

public class AdditionalUpgrades : MonoBehaviour
{
    #region AutoClicker Variables
    [SerializeField, Header("AutoClickerUpgrade")]
    public GameObject displayCost_Clicker;
    public GameObject robot; 
    public static int autoClickerCost = 100;
    [SerializeField]
    private int cost_Clicker;
    #endregion

    #region AutoSeller Variables
    [SerializeField, Header("AutoSellerUpgrade")]
    public GameObject displayCost_Seller;
    public GameObject salesTeam;
    public static int sellerCost = 100;
    [SerializeField]
    private int cost_seller;
    #endregion

    [Space]

    public int costIncrease = 15;

    public GameObject errorMessage;
    #region Variables
    [SerializeField]
    private float timer;

    [SerializeField]
    private float currentCash;
    #endregion


    #region Start and Update
    private void Start()
    {
        currentCash = GameManager.cashCount;

        cost_Clicker = autoClickerCost;
        cost_seller = sellerCost;
    }

    private void Update()
    {
        currentCash = GameManager.cashCount;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            errorMessage.SetActive(false);
            timer = 0;
        }

        //clickerText.text = "Description: Adds an autoclicker cost(Ꞡ): " + Mathf.Round(autoClickerCost);
        //sellerText.text = "Description: Adds an autoSeller cost(Ꞡ): " + Mathf.Round(sellerCost);
    }
    #endregion


    /// <summary>
    /// When the player "buys" a robot<br/>
    /// if their money is greater than or equal to the cost<br/>
    /// the auto clicker is activated. if the player buys another<br/>
    /// robot it will add to the amount and increase production amount 
    /// </summary>
    public void BuyRobot()
    {   
        bool canBuy = currentCash >= autoClickerCost;
        bool cantBuy = currentCash < autoClickerCost;
        currentCash = GameManager.cashCount;
        cost_Clicker = autoClickerCost;

        if (canBuy)
        {
            robot.SetActive(true);
            GameManager.cashCount -= autoClickerCost;
            AutoClicker.autoClick += 1;
        }
        // else if the player doesnt have enough money display error message
        else if (cantBuy)
        {
            errorMessage.SetActive(true);
            timer = 3;
        }
    }

    /// <summary>
    /// When the player "buys" a Member of sales<br/>
    /// if their money is greater than or equal to the cost<br/>
    /// the auto seller is activated. if the player buys another<br/>
    /// sales member it will add to the amount and increase sell amount 
    /// </summary>
    public void BuySalesTeamMember()
    {
        bool canBuy = currentCash >= sellerCost;
        bool cantBuy = currentCash < sellerCost;
        currentCash = GameManager.cashCount;
        cost_seller = sellerCost;

        if (canBuy)
        {
            salesTeam.SetActive(true);
            GameManager.cashCount -= sellerCost;
            AutoSeller.autoClick += 1;
            sellerCost = costIncrease / sellerCost * 100;
        }
        else if (cantBuy)
        {
            errorMessage.SetActive(true);
            timer = 3;
        }

    }
}
