
using System;
using Player.Damage;
using UnityEngine;

public class EnemyDamageBehavior : MonoBehaviour
{
    private static readonly int IsTakingDamage = Animator.StringToHash("isTakingDamage");

    private void OnCollisionStay2D(Collision2D other)
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
