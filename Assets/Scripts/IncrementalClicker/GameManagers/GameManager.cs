using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using incrementalClicker.manager;

namespace incrementalClicker.manager
{
    public class GameManager : MonoBehaviour
    {
        #region Variables
        public static int autoClick;
        public static int autoSell;

        public GameObject autoClicker;
        public GameObject autoSeller;

        public GameObject pause;
        public bool isPaused;

        #region Production Variables
        [SerializeField, Tooltip("Shows the ammount of products produced")]
        private int products;
        [SerializeField]
        public static int production = 0;
        [SerializeField, Tooltip("GameObject with text box component to display information to the player")]
        private GameObject productDisplay;
        #endregion

        #region Money Variables
        [SerializeField, Tooltip("Shows the ammount of money we have")]
        public float money;
        [SerializeField, Tooltip("Shows the amount products are sold for")]
        private float displaySell;
        [SerializeField]
        public static float cashCount;
        public static float sellAmount = 2.5f;
        [SerializeField, Tooltip("GameObject with text box component to display information to the player")]
        private GameObject cashDisplay;
        #endregion
        #endregion

         static public EnhancementButton[] enhancementButtons;


        #region Start and Update

        #region Singleton
        public static GameManager Instance = null;
        private void Awake()
        {
            // If an Instance Exists in Unity
            if (Instance != null)
                Destroy(Instance); // Destroy that instance (to remove duplicates)
                                   // Assign new Instance to this
            Instance = this;

             enhancementButtons = FindObjectsOfType<EnhancementButton>();
        }
        #endregion

        public void SavePlayer()
        {
            SaveSystem.SaveGame();
        }

        public void LoadPlayer()
        {
            SaveSystem.Load();
            PlayerData data = SaveSystem.loadedData.playerData;
            EnchancementData edata = SaveSystem.loadedData.enchancementData;

            production = data.products;
            cashCount = data.money;
            sellAmount = data.sellAmount;
            autoClick = data.autoClicker;
            autoSell = data.autoSeller;

            AutoClicker.autoClick = data.robots;
            AutoSeller.autoClick = data.sellers;

            foreach (EnhancementButton btn in  FindObjectsOfType<EnhancementButton>())
            {
                btn.enhancement = edata.enhancementData[btn.name];
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && isPaused == false)
            {
                pause.SetActive(true);
                isPaused = true;
                Time.timeScale = 0f;
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isPaused == true)
            {
                pause.SetActive(false);
                isPaused = false;
                Time.timeScale = 1f;
            }

            AmountOfProducts();
            CashAmount();

            if (autoClick >= 1)
            {
                autoClicker.SetActive(true);
            }

            if (autoSell >= 1)
            {
                autoSeller.SetActive(true);
            }
        }
        #endregion

        #region Display Text
        /// <summary>
        /// Displays The amount of products made
        /// <br/> in the text box so the player can see
        /// </summary>
        private void AmountOfProducts()
        {
            displaySell = sellAmount;
            products = production;
            productDisplay.GetComponent<Text>().text = "HL3 Copies: " + products;
        }

        /// <summary>
        /// Displays The amount of money made
        /// <br/> in the text box so the player can see
        /// </summary>
        private void CashAmount()
        {
            money = cashCount;
            cashDisplay.GetComponent<Text>().text = "Gabens Earned(Ꞡ): " + Mathf.Round(cashCount);
        }
        #endregion
    }
}