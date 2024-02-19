using UnityEngine;

[CreateAssetMenu]
public class StaticData : ScriptableObject
{
    public GameObject cubePrefab;
    public int dailyRewardAmount;
    public int rewardForLevel;
    public Level[] levels;
}
