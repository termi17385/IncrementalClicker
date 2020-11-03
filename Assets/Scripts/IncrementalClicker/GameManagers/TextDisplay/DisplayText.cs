using incrementalClicker.player;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    PlayerStats player; 
    [SerializeField]
    private GameObject xpText;
    [SerializeField] 
    private GameObject levelText;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
    }


    public void DisplayExperienceStats()
    {
        xpText.GetComponent<Text>().text = PlayerStats.xp + "/" + player.rXp;

        levelText.GetComponent<Text>().text = "Level: " + PlayerStats.level;
    }



    /// <summary>
    /// Displays The amount of products made
    /// <br/> in the text box so the player can see
    /// </summary>
    public void DisplayProducts()
    {
        player.displayProduction.GetComponent<Text>().text = "HL3 Copies: " + PlayerStats.products;
    }

    /// <summary>
    /// Displays The amount of money made
    /// <br/> in the text box so the player can see
    /// </summary>
    public void DisplayMoney()
    {
        if (PlayerStats.money >= 9999999)
        {
            player.displayMoney.GetComponent<Text>().text = "Gabens Earned(Ꞡ): 1Billion+";
        }
        else
        {
            player.displayMoney.GetComponent<Text>().text = "Gabens Earned(Ꞡ): " + Mathf.Round(PlayerStats.money);
        }

        

    }
}
