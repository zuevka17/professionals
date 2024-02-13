using UnityEngine;

public class SceneData : MonoBehaviour
{
    [Header("Spawns Locations")]
    public Transform[] spawnPoints;
    public Transform[] spawnPoints2;
    public Transform[][] levelMassives;
    [Header("Platforms")]
    public GameObject twoByTwoPlatform;
    public GameObject threeByThreePlatform;
    public int currentLevel = 0;

    [Header("Cubes Bools")]
    public bool isLeftCubesMoves = false;
    public bool isRightCubesMoves = false;
    public bool isUpCubesMoves = false;
    public bool isDownCubesMoves = false;
    private void Start()
    {
        levelMassives = new Transform[][] {spawnPoints, spawnPoints2 }; 
    }
}
