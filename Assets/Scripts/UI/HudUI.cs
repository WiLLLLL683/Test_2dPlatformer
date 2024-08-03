using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Platformer
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text bulletAmountText;

        private ItemData bulletItem;

        public void Init(InventoryBase playerInventory)
        {
            if (playerInventory.TryGetItem("Bullet", out ItemData bulletItem))
            {
                bulletItem.OnAmountChange += UpdateBulletAmount;
                UpdateBulletAmount(bulletItem.Amount);
            }
            else
            {
                ShowNoBulletsText();
            }
        }

        private void OnDestroy()
        {
            if (bulletItem != null)
            {
                bulletItem.OnAmountChange -= UpdateBulletAmount;
            }
        }

        private void UpdateBulletAmount(int amount)
        {
            bulletAmountText.text = $"Bullets: {amount}";

            if (amount == 0)
            {
                ShowNoBulletsText();
            }
        }

        private void ShowNoBulletsText()
        {
            bulletAmountText.text = "No Bullets";
        }
    }
}