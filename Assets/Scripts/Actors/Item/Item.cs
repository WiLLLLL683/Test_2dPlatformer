using System;
using System.Collections;
using UnityEngine;

namespace Platformer
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemData itemData;

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