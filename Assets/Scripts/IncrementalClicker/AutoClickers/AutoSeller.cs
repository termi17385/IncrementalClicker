using System.Collections;
using System.Collections.Generic;
using incrementalClicker.manager;
using UnityEngine;

public class AutoSeller : MonoBehaviour
{
    #region variables
    public bool autoSeller = false;
    public static int autoClick = 0;
    private int salesTeam;
    #endregion

    #region AutoSell Methods
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
        if (autoSeller == false)
        {
            autoSeller = true;
            StartCoroutine(Create());
        }
    }

    /// <summary>
    /// adds 1 to the money while removing 1 from the production <br/>
    /// waits for x amount of seconds then<br/> 
    /// sets auto Seller to false 
    /// </summary>
    IEnumerator Create()
    {
        GameManager.production -= autoClick;
        GameManager.cashCount += autoClick;
        yield return new WaitForSeconds(1);
        autoSeller = false;
    }
    #endregion
}
