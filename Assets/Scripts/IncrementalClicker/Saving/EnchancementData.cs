using incrementalClicker.player;
using System.Collections.Generic;

[System.Serializable]
public class EnchancementData 
{   
    // defines the Dictionary
    public Dictionary< string , Enhancement> enhancementData;

    /// <summary>
    /// Used to create the dictionary <br/>
    /// and store the data from the enhancments
    /// </summary>
    public EnchancementData()
    {
        enhancementData = new Dictionary<string, Enhancement>();

        foreach (EnhancementButton button in PlayerStats.enhancementButtons)
        {
            // adds the enhancement button to the dictionary with the name and its corresponding data
            AddButtonToSave(button.name, button);

        }
    }

    /// <summary>
    /// Method for adding enhancements to the dictionary
    /// </summary>
    /// <param name="btnID">Name of the button</param>
    /// <param name="data">The buttons data</param>
    public void AddButtonToSave(string btnID ,EnhancementButton data)
    {
        enhancementData.Add(btnID, data.enhancement);
    }

    /// <summary>
    /// Used to load the button and its data
    /// </summary>
    /// <param name="loadToThis">Where the data is loaded too</param>
    /// <param name="btnID">The name of the button the data is loading</param>
    public EnhancementButton load(EnhancementButton loadToThis, string btnID)
    {    
        // Loads the data to the matching button name
        loadToThis.enhancement = enhancementData[btnID];
        return loadToThis;
    }

}
