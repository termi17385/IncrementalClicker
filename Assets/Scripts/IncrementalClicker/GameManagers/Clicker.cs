using incrementalClicker.player;
using System.Collections;
using UnityEngine;


public class Clicker : MonoBehaviour
{
    #region Variables
    [Space]
    [SerializeField, Tooltip("used to display the timer in the inspector")]
    public float Displaytimer;  
    [SerializeField] private bool canGainXp = false;
    [SerializeField] private bool timer = false;
    [SerializeField, Tooltip("Used to activate the Error message gameObject")]
    public GameObject errorMessage;
    #endregion


    #region Misc
    /// <summary>
    /// Timer used to disable error message after set time
    /// </summary>
    public void _timer()
    {
        if (timer == false)
        {
            StartCoroutine(Experience());
        }

        Displaytimer -= Time.deltaTime;

        if(Displaytimer <= 0)
        {
            Displaytimer = 0;
            errorMessage.SetActive(false);
        }
    }
    #endregion

    #region Production and selling
    
    public void MakeGame()
    {
        PlayerStats.products += 1;
    }

    public void SellGame()
    {
        float xpAmount = 0.05f;
        if (PlayerStats.products == 0)
        {
            // displays error message letting the player know they need more production
            errorMessage.SetActive(true);
            Displaytimer = 2;
        }
        else
        {
            PlayerStats.products -= 1;
            PlayerStats.money += PlayerStats.sellAmount;
            
            if (canGainXp == true)
            {
                PlayerStats.xp += xpAmount;
            }
            
        }
        
    }
    #endregion


    IEnumerator Experience()
    {
        canGainXp = true;
        timer = false;
        yield return new WaitForSeconds(1);

    }


}
