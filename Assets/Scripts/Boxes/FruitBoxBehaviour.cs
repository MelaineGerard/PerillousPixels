using Game;
using UnityEngine;

namespace Boxes
{
    public class FruitBoxBehaviour : MonoBehaviour
    {
        public string animationName;
        public Animator animator;
        public AudioSource audioSource;
        public AudioClip audioClip;

    
        public int fruitsToGet;

        private void Start()
        {
            GameManager.Instance.AddFruits(fruitsToGet);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (other.contacts[0].normal.y > 0.5f)
                {
                    GameManager.Instance.CollectFruits(fruitsToGet);
                    animator.Play(animationName);
                    audioSource.PlayOneShot(audioClip);
                }
            }
        }
    
        public void DestroyObject()
        {
            Destroy(gameObject);
        }
    }
}
