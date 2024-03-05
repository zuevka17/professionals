using UnityEngine;

namespace basketball
{
    [CreateAssetMenu]
    public class StaticData : ScriptableObject
    {
        public GameObject BallPrefab;
        public Level[] Levels;
    }
}
