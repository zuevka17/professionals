using UnityEngine;

namespace cubes
{
    public abstract class Screens : MonoBehaviour
    {
        public virtual void Show(bool state = true)
        {
            gameObject.SetActive(state);
        }
    }
}
