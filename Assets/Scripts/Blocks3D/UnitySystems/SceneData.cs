using UnityEngine;

namespace cubes
{
    public class SceneData : MonoBehaviour
    {
        public int currentLevel = 0;
        public GameObject currentCenter;

        [Header("Cubes Bools")]
        public bool isLeftCubesMoves = false;
        public bool isRightCubesMoves = false;
        public bool isUpCubesMoves = false;
        public bool isDownCubesMoves = false;
    }
}
