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
        public static int production;
        [SerializeField, Tooltip("GameObject with text box component to display information to the player")]
        private GameObject productDisplay;
        #endregion

        #region Money Variables
        [SerializeField, Tooltip("Shows the ammount of money we have")]
        public float money;   
        [SerializeField]
        public static float cashCount;
        [SerializeField, Tooltip("GameObject with text box component to display information to the player")]
        private GameObject cashDisplay;
        #endregion
        #endregion

        #region Start and Update
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