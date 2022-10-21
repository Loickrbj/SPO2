using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed = 12f;
        [SerializeField] private float gravity = -9.81f;

        private Vector3 velocity;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.2f;
        [SerializeField] private LayerMask groundMask;

        private bool isGrounded;

        void Update()
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            characterController.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;

            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
