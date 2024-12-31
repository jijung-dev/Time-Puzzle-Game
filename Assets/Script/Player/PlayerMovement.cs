using UnityEngine;

namespace Script.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed;
        [SerializeField] private Rigidbody2D rb;

        private Vector2 _moveDirection;

        private void Update()
        {
            ProcessInputs();
        }

        private void FixedUpdate()
        {
            rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
        }

        private void ProcessInputs()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            _moveDirection = new Vector2(moveX, moveY).normalized;
        }
    }
}