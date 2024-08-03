using System;
using UnityEngine;

namespace Platformer
{
    [System.Serializable]
    public class Item
    {
        public string Name;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnAmountChange?.Invoke(amount);
            }
        }

        [SerializeField] private int amount;

        [field: NonSerialized] public event Action<int> OnAmountChange;
    }
}