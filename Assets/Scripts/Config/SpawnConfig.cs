using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "SpawnConfig", menuName = "GameConfig/SpawnConfig")]
    public class SpawnConfig : ScriptableObject
    {
        public Player playerPrefab;
        public Enemy[] enemyPrefabs;
        public float minMoveSpeed;
        public float maxMoveSpeed;
    }
}