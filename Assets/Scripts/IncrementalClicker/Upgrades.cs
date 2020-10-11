using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using incrementalClicker.manager;

public class Upgrades : MonoBehaviour
{
    #region GameObjects
    [SerializeField]
    public GameObject autoClickerPrice;
    [SerializeField]
    public GameObject robot;
    [SerializeField]
    public GameObject errorMessage;
    #endregion

    #region Variables
    [SerializeField]
    private float timer;
    [SerializeField]
    public static int _cost = 100;
    [SerializeField]
    private int cost;
    [SerializeField]
    private float currentCash;
    #endregion


    #region Start and Update
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            errorMessage.SetActive(false);
            timer = 0;
        }
        autoClickerPrice.GetComponent<Text>().text = "Descritpion: Adds an autoclicker cost(Ꞡ): " + Mathf.Round(_cost);
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
        currentCash = GameManager.cashCount;
        cost = _cost;
        int costIncrease = 15;

        if (currentCash >= _cost)
        {
            robot.SetActive(true);
            GameManager.cashCount -= _cost;

            // used to increase the cost of the upgrade 
            // after purchase
            _cost = _cost * (1 + (costIncrease / 100));
            AutoClicker.autoClick += 1;
        }
        // else if the player doesnt have enough money display error message
        else if (currentCash < _cost)
        {
            errorMessage.SetActive(true);
            timer = 3;
        }
    }
}
