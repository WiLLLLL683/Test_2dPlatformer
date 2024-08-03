using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class ItemDrop : ItemDropBase
    {
        [SerializeField] private List<ItemData> dropItems;
        [SerializeField] private int minDropAmount;
        [SerializeField] private int maxDropAmount;

        private ItemSpawner itemSpawner;

        public override void Init(ItemSpawner itemSpawner)
        {
            this.itemSpawner = itemSpawner;
        }

        public override void DropItem()
        {
            int random = Random.Range(0, dropItems.Count);
            ItemData itemData = dropItems[random];
            itemData.Amount = Random.Range(minDropAmount, maxDropAmount);
            itemSpawner.Spawn(itemData, transform.position);
        }
    }
}