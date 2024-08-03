using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ItemSet", menuName = "GameConfig/ItemSet")]
    public class ItemSetConfig : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> items = new();

        public bool TryGetItem(string id, out ItemConfig item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == id)
                {
                    item = items[i];
                    return true;
                }
            }

            item = null;
            return false;
        }
    }
}