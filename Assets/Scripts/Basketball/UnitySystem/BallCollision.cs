using Leopotam.Ecs;
using UnityEngine;

namespace basketball
{
    public class BallCollision : MonoBehaviour
    {
        [SerializeField]private EcsInit world;
        private void Awake()
        {
            world = GameObject.Find("EcsInit").gameObject.GetComponent<EcsInit>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                world.World.NewEntity().Get<TouchFloorEvent>();
                Debug.Log(collision.gameObject.name);
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Basket")
            {
                world.World.NewEntity().Get<GoalEvent>();
            }
        }
    }
}
