using Player.Datas;
using UnityEngine;

namespace Player.Movement
{
    public class PlayerMovementBehaviour : MonoBehaviour
    {
        [Header("References")]
        public CharacterData characterData;
        public Rigidbody2D rb;
        public SpriteRenderer spriteRenderer;
        public Animator animator;
        public GameObject leftSide;
        public GameObject rightSide;
        public LayerMask collisionMask;
        
        [Header("Attributes")]
        public float distance = 0.55f;
        
        
        private static readonly int IsRunning = Animator.StringToHash("isRunning");
        private static readonly int VerticalSpeed = Animator.StringToHash("verticalSpeed");

        
        private void OnValidate()
        {
            animator.runtimeAnimatorController = characterData.animatorController;
        }

        private void Start()
        {
            spriteRenderer.sprite = characterData.defaultSprite;
        }

        void Update()
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(leftSide.transform.position, Vector2.down, distance, collisionMask);
            RaycastHit2D hitMiddle = Physics2D.Raycast(transform.position, Vector2.down, distance, collisionMask);
            RaycastHit2D hitRight = Physics2D.Raycast(rightSide.transform.position, Vector2.down, distance, collisionMask);
            bool isGrounded = hitLeft.collider || hitMiddle.collider || hitRight.collider;
            bool notJumping = Mathf.Approximately(Mathf.Round(rb.velocity.y), 0);
            
            animator.SetFloat(VerticalSpeed, notJumping ? 0 : rb.velocity.y);
            
            
            if (Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.LeftArrow))
            {
                spriteRenderer.flipX = true;
                rb.velocity = new Vector2(-characterData.speed, rb.velocity.y);
                animator.SetBool(IsRunning, notJumping);

            } else if (Input.GetKey(KeyCode.D) ^ Input.GetKey(KeyCode.RightArrow))
            {
                spriteRenderer.flipX = false;
                rb.velocity = new Vector2(characterData.speed, rb.velocity.y);
                animator.SetBool(IsRunning, notJumping);
            }
            else
            {
                animator.SetBool(IsRunning, false);
            }
            
            if ((Input.GetKeyDown(KeyCode.Space) ^ Input.GetKeyDown(KeyCode.W) ^ Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
            {
                rb.AddForce(Vector2.up * characterData.jumpForce);
            }
        }
    }
}
