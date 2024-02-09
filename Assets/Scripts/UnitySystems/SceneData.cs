using System.Collections.Generic;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [Header("Spawns Locations")]
    public Transform[] spawnPoints;

    [Header("Cubes Bools")]
    public bool isLeftCubesMoves = false;
    public bool isRightCubesMoves = false;
    public bool isUpCubesMoves = false;
    public bool isDownCubesMoves = false;
}
