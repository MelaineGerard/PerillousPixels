using System;
using Player.Damage;
using UnityEngine;

namespace Trap
{
    public class TrapBehaviour : MonoBehaviour
    {
        private static readonly int IsTakingDamage = Animator.StringToHash("isTakingDamage");

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") 
                && other.gameObject.GetComponent<PlayerDamageBehaviour>().animator.GetBool(IsTakingDamage) == false
                && other.gameObject.GetComponent<PlayerDamageBehaviour>().isTakingDamage == false
               )
            {
                other.gameObject.GetComponent<PlayerDamageBehaviour>().Damage();
            }
        }
    }
}
