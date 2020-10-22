using incrementalClicker.manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnhancementButton : MonoBehaviour
{
    // creates a new instance of the Enhancement class
    public Enhancement enhancement = new Enhancement();
    public Text descriptionText;
   
    private void Update()
    {
        descriptionText.text = "Description: " + enhancement.description + "\n" +
            "Cost: " + Mathf.Round(enhancement.cost);
    }

    /// <summary>
    /// Main method for handling the logic of the Enhancements
    /// </summary>
    public void Buy()
    {
        if (GameManager.cashCount >= enhancement.cost)
        {
            GameManager.cashCount -= enhancement.cost;

            // outcome

            // cost increase
        }
        else
        {
            print("Need more money");
        }
    }
}

