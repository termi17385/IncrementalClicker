using incrementalClicker.player;

public class ClickerButton : UpgradeButton
{
    public static float cost = 250;
    public static float costIncrease = 25;

    private void Start()
    {
        upgrade.cost = cost;
        upgrade.costIncrease = costIncrease;  
    }

    private void Update()
    {
        upgrade.cost = cost;
        upgrade.costIncrease = costIncrease;
    }

    // override method for the auto clicker button
    // overrides from upgrade class
    public override void Buy()
    {
        upgrade.cost = cost;
        upgrade.costIncrease = costIncrease;

        // checks if player has enough money
        if (PlayerStats.money >= upgrade.cost)
        {
            // if true activates clicker
            gameObject.SetActive(true);
            // subracts the players money by the upgrades cost
            PlayerStats.money -= cost;
            // adds an autoclicker
            AutoClicker.autoClick += 1;
            // increases the cost by a set percentage
            cost = cost * (1 + (costIncrease / 100));
        }

        print("Called Clicker's Buy!");
    }
}
