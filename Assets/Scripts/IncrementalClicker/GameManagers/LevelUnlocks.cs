using incrementalClicker.player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUnlocks : MonoBehaviour
{
    [SerializeField] private GameObject upgrade1, upgrade2, upgrade3, upgrade4;
    [SerializeField] private GameObject autoClicker, autoSeller;

    private void Start()
    {
        upgrade1.SetActive(false);
        upgrade2.SetActive(false);
        upgrade3.SetActive(false);
        upgrade4.SetActive(false);

        autoClicker.SetActive(false);
        autoSeller.SetActive(false);
    }

    private void Update()
    {
        UnlockUpgrade();
    }

    private void UnlockUpgrade()
    {
        if (PlayerStats.level == 6)
        {
            upgrade1.SetActive(true);
        }
        if (PlayerStats.level == 8)
        {
            upgrade2.SetActive(true);
        }
        if (PlayerStats.level == 15)
        {
            upgrade3.SetActive(true);
        }
        if (PlayerStats.level == 20)
        {
            upgrade4.SetActive(true);
        }
        if (PlayerStats.level == 2)
        {
            autoClicker.SetActive(true);
        }
        if (PlayerStats.level == 3)
        {
            autoSeller.SetActive(true);
        }
    }
}
