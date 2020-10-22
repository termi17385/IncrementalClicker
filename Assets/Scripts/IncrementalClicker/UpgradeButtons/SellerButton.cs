using incrementalClicker.manager;

public class SellerButton : UpgradeButton
{
    // override method for the auto clicker button
    // overrides from upgrade class
    public override void Buy()
    {
        // checks if player has enough money
        if (GameManager.cashCount >= upgrade.cost)
        {
            // if true activates clicker
            gameObject.SetActive(true);
            // subracts the players money by the upgrades cost
            GameManager.cashCount -= upgrade.cost;
            // adds an autoclicker
            AutoSeller.autoClick += 1;

            // cost increase
        }
        print("Called Seller's Buy!");
    }
}
