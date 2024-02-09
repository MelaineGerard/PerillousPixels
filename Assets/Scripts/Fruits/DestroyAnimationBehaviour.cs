using UnityEngine;

namespace Fruits
{
    public class DestroyAnimationBehaviour : MonoBehaviour
    {
        public void DestroyAnimationFinished()
        {
            Destroy(gameObject);
        }
    }
}
