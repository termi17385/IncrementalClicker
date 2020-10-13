﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using incrementalClicker.manager;

public class AutoClicker : MonoBehaviour
{
    #region variables
    public bool autoProduction = false;
    public static int autoClick = 0;
    private int robots;
    #endregion

    #region AutoClick Methods
    private void Update()
    {
        _AutoClicker();
    }

    /// <summary>
    /// Shows amount of robots bought and<br/>
    /// activates the coroutine
    /// </summary>
    private void _AutoClicker()
    {
        robots = autoClick;
        if (autoProduction == false)
        {
            autoProduction = true;
            StartCoroutine(Create());
        }
    }

    /// <summary>
    /// adds 1 to the production waits for x amount<br/> 
    /// of seconds then sets auto production to false 
    /// </summary>
    IEnumerator Create()
    {
        GameManager.production += autoClick;
        yield return new WaitForSeconds(1);
        autoProduction = false;
    }
    #endregion
}