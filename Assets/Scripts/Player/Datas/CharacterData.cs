using UnityEngine;

namespace Player.Datas
{
    [CreateAssetMenu(menuName = "Game/Player/CharacterData")]
    public class CharacterData : ScriptableObject
    {
        [Header("Attributes")]
        public float speed;
        public float jumpForce;
        public float maxHealth;

        [Header("References")] 
        public RuntimeAnimatorController animatorController;
        public Sprite defaultSprite;
    }
}