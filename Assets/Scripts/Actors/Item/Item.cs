using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Item : MonoBehaviour
    {
        [Header("Current state")]
        [SerializeField] private ItemData itemData;

        public void Init(ItemData data)
        {
            itemData = data;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<InventoryBase>(out InventoryBase inventory))
            {
                inventory.AddItem(itemData);
                Destroy(gameObject);
            }
        }
    }
}