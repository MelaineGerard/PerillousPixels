using System;
using Game;
using UnityEngine;

namespace Fruits
{
    public class FruitBehaviour: CollectibleBehaviour
    {
        [Header("References")]
        public GameObject destroyAnimationPrefab;
        public AudioSource audioSource;
        public AudioClip audioClip;
        public FruitData fruitData;
        public SpriteRenderer spriteRenderer;
        public Animator animator;

        private void OnValidate()
        {
            animator.runtimeAnimatorController = fruitData.animatorController;
        }

        private void Start()
        {
            spriteRenderer.sprite = fruitData.defaultSprite;
            GameManager.Instance.AddFruits(fruitData.fruitsToGet);
        }
        
        protected override void OnDestroyFruits()
        {
            GameManager.Instance.CollectFruits(1);
            audioSource.PlayOneShot(audioClip);
            Instantiate(destroyAnimationPrefab, transform.position, Quaternion.identity);
        }
    }
}