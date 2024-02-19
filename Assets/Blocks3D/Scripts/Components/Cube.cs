using UnityEngine;

public struct Cube
{
    public GameObject go;

    public ColliderTest test;
    public bool hasTouched;

    public float distanceToMove;
    public Vector3 finPoint;

    public Rigidbody cubeRigidbody;
    public Transform cubePosition;
}
