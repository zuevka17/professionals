using UnityEngine;

public class ColliderTest : MonoBehaviour
{
    public bool touched = false;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cube")
        {
            Debug.Log("Cubes Touched");
            touched = true;
        }
    }
}
