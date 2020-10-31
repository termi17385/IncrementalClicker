using incrementalClicker.player;
using UnityEngine;
using UnityEngine.UI;

public class DisplayText : MonoBehaviour
{
    PlayerStats player;

    private void Start()
    {
        player = GetComponent<PlayerStats>();
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
        player.displayMoney.GetComponent<Text>().text = "Gabens Earned(Ꞡ): " + Mathf.Round(PlayerStats.money);
    }
}
