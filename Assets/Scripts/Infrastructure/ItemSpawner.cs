using System;
using UnityEngine;

namespace Platformer
{
    public class ItemSpawner
    {
        private readonly ItemSetConfig itemSet;

        public ItemSpawner(ItemSetConfig itemSet)
        {
            this.itemSet = itemSet;
        }

        public Item Spawn(ItemData itemData, Vector2 position)
        {
            if (!itemSet.TryGetItem(itemData.Id, out ItemConfig config))
            {
                Debug.LogError($"Cant find item config with Id = {itemData.Id}", itemSet);
                return null;
            }

            Item item = GameObject.Instantiate(config.prefab, position, Quaternion.identity);
            item.Init(itemData);
            return item;
        }
    }
}