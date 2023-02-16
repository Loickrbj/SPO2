using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Player
{
    public class PlayerController : MonoBehaviourPun
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed = 3f;
        [SerializeField] private float gravity = -9.81f;

        private Vector3 velocity;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.2f;
        [SerializeField] private LayerMask groundMask;

        private bool isMoving;
        private bool isGrounded;

        void Start()
        {
            if (!photonView.IsMine)
            {
                this.enabled = false;
                return;
            }
        }

        void Update()
        {
            if (!photonView.IsMine) return;

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0f)
            {
                velocity.y = -2f;
            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            if (move != Vector3.zero)
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if (isMoving != animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", isMoving);
            }

            characterController.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }
    }
}
