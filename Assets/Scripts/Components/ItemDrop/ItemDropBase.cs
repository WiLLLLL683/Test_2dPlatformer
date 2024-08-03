using UnityEngine;

namespace Platformer
{
    public abstract class ItemDropBase: MonoBehaviour
    {
        public abstract void Init(ItemSpawner itemSpawner);
        public abstract void DropItem();
    }
}