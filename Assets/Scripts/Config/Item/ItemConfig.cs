using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Item", menuName = "GameConfig/Item")]
    public class ItemConfig : ScriptableObject
    {
        public string Id;
        public string Name;
        public Item prefab;
    }
}