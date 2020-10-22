using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UpgradeButton : MonoBehaviour
{
    // creates a new instance of the upgrade class
    public Upgrade upgrade = new Upgrade();
    public GameObject gameObject;
    public Text descriptionText;

    private void Update()
    {
        descriptionText.text = "Description: " + upgrade.description + Mathf.Round(upgrade.cost);
    }
    
    
    public abstract void Buy();
}
