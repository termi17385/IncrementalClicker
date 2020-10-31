using incrementalClicker.player;
using UnityEngine;
using UnityEngine.UI;

public class EnhancementButton : MonoBehaviour
{
    // creates a new instance of the Enhancement class
    public Enhancement enhancement = new Enhancement();
    public GameObject upgrade;
    public Text descriptionText;
   
    private void Update()
    {
        descriptionText.text = "Description: " + enhancement.description + "\n" +
            "Cost: " + Mathf.Round(enhancement.cost);
    }

    /// <summary>
    /// Main method for handling the logic of the Enhancements
    /// </summary>
    public void Buy() // make abstract later and make 2 new classes 1 for money enhancement and 1 for production enhancement
    {
        #region Bools
        bool canBuy = PlayerStats.money >= enhancement.cost;
        bool underMaxUse = enhancement.counter < enhancement.maxUse;
        bool maxUse = enhancement.counter >= enhancement.maxUse;
        #endregion

        if (canBuy && underMaxUse)
        {
            PlayerStats.money -= enhancement.cost;
            enhancement.counter++;

            PlayerStats.sellAmount = PlayerStats.sellAmount * (1 + (enhancement.moneyFactor / 100));

            enhancement.cost = enhancement.cost * (1 + (enhancement.costIncrease / 100));
        }
        else if (maxUse)
        {
            upgrade.SetActive(false);
        }
        else
        {
            print("Need more money");
        }
    }
}

