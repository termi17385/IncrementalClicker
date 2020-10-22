using System.Collections;
using UnityEngine;
using System;
using incrementalClicker.manager;


public class Clicker : MonoBehaviour
{
    #region Variables
    [SerializeField, Tooltip("used to display the timer in the inspector")]
    private float Displaytimer;  
    
    [SerializeField, Tooltip("Used to activate the Error message gameObject")]
    private GameObject errorMessage;
    #endregion

    #region Start and Update
    private void Start()
    {
        
        errorMessage.SetActive(false);
    }

    private void Update()
    {
        _timer();
    }
    #endregion

    #region Misc
    /// <summary>
    /// Timer used to disable error message after set time
    /// </summary>
    private void _timer()
    {
        Displaytimer -= Time.deltaTime;

        if(Displaytimer <= 0)
        {
            Displaytimer = 0;
            errorMessage.SetActive(false);
        }
    }
    #endregion

    #region Production and selling
    /// <summary>
    /// Pressing the button increases the production
    /// </summary>
    public void ClickButton()
    {
            GameManager.production += 1;
    }

    /// <summary>
    /// When the sell button is click it will sell the product and add x ammount to the money
    /// </summary>
    public void SellGame()
    {
        if (GameManager.production == 0)
        {
            // displays error message letting the player know they need more production
            errorMessage.SetActive(true);
            Displaytimer = 2;
        }
        else
        {
            GameManager.production -= 1;
            GameManager.cashCount += 2.5f;
        }
    }
    #endregion
}
