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
        }
        #endregion

        private void Update()
        {
            AmountOfProducts();
            CashAmount();
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