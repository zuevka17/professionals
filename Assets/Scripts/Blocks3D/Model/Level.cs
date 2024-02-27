using System;
using UnityEngine;

namespace cubes
{
    [Serializable]
    public class Level
    {
        public int LevelNumber;
        public int CubesCount;
        public Coordinates Cords;
        public Rotation Rotations;
    }
}
