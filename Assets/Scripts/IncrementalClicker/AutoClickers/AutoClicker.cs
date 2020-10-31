using incrementalClicker.player;
using System.Collections;
using UnityEngine;

public class AutoClicker : MonoBehaviour
{
    #region variables
    public bool autoProduction = false;
    public static int autoClick = 0;

    [SerializeField]
    private int robots;
    #endregion

    #region AutoClick Methods
    private void Start()
    {
        PlayerStats.autoClickSave = true;
    }

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
        PlayerStats.products += autoClick;
        yield return new WaitForSeconds(1);
        autoProduction = false;
    }
    #endregion
}
