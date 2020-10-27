using System;
// For Upgrade 1, 2, 3, 4
[Serializable]
public class Enhancement : Upgrade
{
    public int maxUse = 5;
    public int counter = 0;
    public float moneyFactor = 1f;
}