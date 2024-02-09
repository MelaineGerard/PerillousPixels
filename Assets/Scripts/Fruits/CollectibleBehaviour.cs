using System;
using UnityEngine;

namespace Fruits
{
    public class CollectibleBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                OnDestroyFruits();
            }
        }
        
        protected virtual void OnDestroyFruits()
        {
        }
    }
}
