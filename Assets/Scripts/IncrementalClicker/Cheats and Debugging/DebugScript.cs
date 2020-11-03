using incrementalClicker.player;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    public GameObject debugMenu;
    public int count = 0;

    private void Update()
    {
        OpenTools();
    }

    private void OpenTools()
    {

        bool openTools = Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D);

        if (openTools && count <= 0)
        {
            debugMenu.SetActive(true);
            count++;
        }
        else if (openTools && count >= 1)
        {
            debugMenu.SetActive(false);
            count = 0;
        } 
    }


    public void DebugGiveMoney(float Money)
    {
        PlayerStats.money += Money;
    }
    public void DebugClearMoney()
    {
        PlayerStats.money = 0;
    }
}
