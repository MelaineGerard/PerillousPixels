using UnityEngine;

namespace Fruits
{
    [CreateAssetMenu(menuName = "Game/Fruits/FruitData")]
    public class FruitData : ScriptableObject
    {
        [Header("References")]
        public RuntimeAnimatorController animatorController;
        public Sprite defaultSprite;

        [Header("Attributes")]
        public int fruitsToGet = 1;
    }
}
