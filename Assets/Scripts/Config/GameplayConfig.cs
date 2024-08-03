using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "GameplayConfig", menuName = "GameConfig/GameplayConfig")]
public class GameplayConfig : ScriptableObject
{
    [Tooltip("This item should be in player inventory")]
    public string criticalItem;
    public float enemySpawnDelay;
    public int enemySpawnCount;
}
