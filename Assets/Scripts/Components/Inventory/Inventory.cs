using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class Inventory : InventoryBase
    {
        [SerializeField] private List<ItemData> initialItems;

        private Dictionary<string, ItemData> items = new();

        public override void Init()
        {
            for (int i = 0; i < initialItems.Count; i++)
            {
                AddItem(initialItems[i]);
            }
        }

        public override void AddItem(ItemData item)
        {
            if (items.TryGetValue(item.Name, out ItemData itemInInventory))
            {
                itemInInventory.Amount += item.Amount;
            }
            else
            {
                items.Add(item.Name, item);
            }
        }

        public override bool TryGetItem(string name, out ItemData item)
        {
            if (!items.ContainsKey(name))
            {
                item = null;
                return false;
            }

            item = items[name];
            return true;
        }
    }
}
