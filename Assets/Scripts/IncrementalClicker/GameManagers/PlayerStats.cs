using incrementalClicker;
using UnityEngine;

namespace incrementalClicker.player
{
    [System.Serializable]
    public class PlayerStats : MonoBehaviour 
    {
        #region Variables

        #region Production
        [Header("ProductionStats")]
        [SerializeField, Tooltip("Amount of products")]
        private int _products;
        public static int products;
        [SerializeField, Tooltip("Shows when the autoClicker is on")]
        private bool _autoClickSave;
        public static bool autoClickSave;
        [SerializeField, Tooltip("Used to display the text")]
        public GameObject displayProduction;
        [SerializeField]
        public GameObject activiteAutoClicker;
        #endregion

        #region Money
        [Header("MoneyStats")]
        [SerializeField, Tooltip("Amount of money")]
        private float _money;
        public static float money;
        [SerializeField, Tooltip("How much to sell by")]
        private float _sellAmount;
        public static float sellAmount = 2.5f;
        [SerializeField, Tooltip("Shows when the autoSeller is on")]
        private bool _autoSellSave;
        public static bool autoSellSave;
        [SerializeField, Tooltip("Used to display the text")]
        public GameObject displayMoney;
        [SerializeField]
        public GameObject activiateAutoSeller;
        #endregion

        [Space]

        [Header("Misc")]
        [SerializeField]
        private EnhancementButton[] _enhancementButtons;
        public static EnhancementButton[] enhancementButtons;
        [SerializeField]
        private Clicker clicker;
        [SerializeField]
        private DisplayText text;
        
        [SerializeField] private GameObject autoSaver;
        [SerializeField] private bool loadSave;
        [SerializeField] private bool autoSaving;
        public static bool autoLoad;
        public static bool autoSave;
        #endregion

        #region Start and Update
        protected void Start()
        {
            clicker.errorMessage.SetActive(false);

            if(autoLoad == true)
            {
                LoadPlayer();
            }
        }

        protected void Update()
        {
            #region Setting Variables
            loadSave = autoLoad;
            autoSaving = autoSave;

            _autoClickSave = autoClickSave;
            _autoSellSave = autoSellSave;

            _products = products;
            _money = money;
            _sellAmount = sellAmount;

            enhancementButtons = _enhancementButtons;
            #endregion


            #region Clicker Methods
            clicker._timer();
            #endregion

            #region Display Text
            text.DisplayMoney();
            text.DisplayProducts();
            #endregion

            ActivateAutoSaver();
            CheckIfAutoClickerIsSaved();
        }
        #endregion

        #region SavingStuff
        public void SavePlayer()
        {
            SaveSystem.SaveGame();
        }

        public void LoadPlayer()
        {
            SaveSystem.Load();
            PlayerData data = SaveSystem.loadedData.playerData;
            EnchancementData edata = SaveSystem.loadedData.enchancementData;

            products = data.products;
            money = data.money;
            sellAmount = data.sellAmount;
            autoClickSave = data.autoClicker;
            autoSellSave = data.autoSeller;

            AutoClicker.autoClick = data.robots;
            AutoSeller.autoClick = data.sellers;

            ClickerButton.cost = data.clickerCost;
            ClickerButton.costIncrease = data.clickerCostIncrease;

            SellerButton.cost = data.sellerCost;
            SellerButton.costIncrease = data.sellerCostIncrease;

            foreach (EnhancementButton btn in FindObjectsOfType<EnhancementButton>())
            {
                btn.enhancement = edata.enhancementData[btn.name];
            }
        }

        private void CheckIfAutoClickerIsSaved()
        {
            if (autoClickSave == true)
            {
                activiteAutoClicker.SetActive(true);
            }

            if (autoSellSave == true)
            {
                activiateAutoSeller.SetActive(true);
            }
        }

        private void ActivateAutoSaver()
        {
            if (autoSave == true)
            {
                autoSaver.SetActive(true);
            }
            else
            {
                autoSaver.SetActive(false);
            }
        }
        #endregion
    }
}
