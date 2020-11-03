using incrementalClicker.player;
using System.Collections;
using UnityEngine;

public class AutoSeller : MonoBehaviour
{
    #region variables
    public bool autoSeller = false;
    public static int autoClick = 0;

    [SerializeField]
    private int salesTeam;
    #endregion

    #region AutoSell Methods
    private void Start()
    {
        salesTeam = autoClick;
        PlayerStats.autoSellSave = true;
    }

    private void Update()
    {
        _AutoSeller();
    }

    /// <summary>
    /// Shows amount of salesTeam members bought and<br/>
    /// activates the coroutine
    /// </summary>
    private void _AutoSeller()
    {
        salesTeam = autoClick;
        
        bool canAutoSell = (autoSeller == false) && (PlayerStats.products >= salesTeam);
        bool cantAutoSell = (PlayerStats.products <= 0);

        
       
        if (canAutoSell)
        {
            autoSeller = true;
            StartCoroutine(Sell());
        }
        else if (cantAutoSell)
        {
            Debug.Log("Need More Production");
        }
    }

    /// <summary>
    /// adds 1 to the money while removing 1 from the production <br/>
    /// waits for x amount of seconds then<br/> 
    /// sets auto Seller to false 
    /// </summary>
    IEnumerator Sell()
    {  
        float xpAmount = 0.001f;
        float cashIncrease = PlayerStats.sellAmount * autoClick;
        PlayerStats.products -= autoClick;
        PlayerStats.money += cashIncrease;
        PlayerStats.xp += xpAmount;
        yield return new WaitForSeconds(1);
        autoSeller = false;       
    }
    #endregion
}
