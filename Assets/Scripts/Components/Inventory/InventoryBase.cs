using UnityEngine;

namespace Platformer
{
    public abstract class InventoryBase : MonoBehaviour
    {
        public abstract void Init();
        public abstract void AddItem(Item item);
        public abstract bool TryGetItem(string name, out Item item);
    }
}