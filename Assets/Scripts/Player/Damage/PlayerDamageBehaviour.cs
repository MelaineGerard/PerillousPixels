using System;
using Game;
using Player.Datas;
using UnityEngine;

namespace Player.Damage
{
    public class PlayerDamageBehaviour : MonoBehaviour
    {
        [Header("References")]
        public Animator animator;
        public CharacterData characterData;
        public AudioSource audioSource;
        public AudioClip audioClip;
        
        [Header("Attributes")]
        public bool isTakingDamage;
        public float currentHealth;
        
        private static readonly int IsTakingDamage = Animator.StringToHash("isTakingDamage");

        private void Start()
        {
            currentHealth = characterData.maxHealth;
        }

        public void Damage()
        {
            isTakingDamage = true;
            currentHealth--;
            
            GameManager.Instance.UpdateHealth(currentHealth, characterData.maxHealth);
            animator.Play("VirtualGuyHit");
            animator.SetBool(IsTakingDamage, true);
            audioSource.PlayOneShot(audioClip);
        }

        public void StopDamage()
        {
            animator.SetBool(IsTakingDamage, false);
            isTakingDamage = false;
        }
    }
}
