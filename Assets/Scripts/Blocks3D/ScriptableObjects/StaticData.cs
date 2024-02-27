using UnityEngine;

namespace cubes
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject cubePrefab;
        public int dailyRewardAmount;
        public int rewardForLevel;
        public Level[] levels;
    }
}