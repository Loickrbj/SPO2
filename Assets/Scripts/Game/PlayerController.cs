using Photon.Pun;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Player
{
    public class PlayerController : MonoBehaviourPun
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        [SerializeField] private List<Color> colorList;
        private Material material;

        private float speed = 3f;
        private float gravity = -9.81f;

        [SerializeField] private List<AudioClip> stepSounds;
        [SerializeField] private AudioSource stepAudioSource;
        private float stepTime;
        private float stepMaxTime = 0.5f;

        private Vector3 velocity;

        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundDistance = 0.2f;
        [SerializeField] private LayerMask groundMask;

        private bool isMoving;
        private bool isGrounded;

        private void Start()
        {
            if (!photonView.IsMine)
            {
                this.enabled = false;
                return;
            }

            photonView.RPC("ChangeColor", RpcTarget.AllBuffered, PhotonNetwork.PlayerList.Length - 2);
        }

        private void Update()
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

            stepTime += Time.deltaTime;
            if (isMoving && stepTime >= stepMaxTime)
            {
                photonView.RPC("PlayStepSound", RpcTarget.All);
            }

            characterController.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            characterController.Move(velocity * Time.deltaTime);
        }

        [PunRPC]
        private void ChangeColor(int colorIndex)
        {
            if (colorIndex < 0 || colorIndex >= colorList.Count)
            {
                return;
            }

            SkinnedMeshRenderer renderer = GetComponentInChildren<SkinnedMeshRenderer>();
            material = new Material(renderer.material);
            renderer.material = material;
            material.color = colorList[colorIndex];
        }

        [PunRPC]
        private void PlayStepSound()
        {
            stepTime = 0;
            int stepIndex = Random.Range(0, stepSounds.Count);
            stepAudioSource.clip = stepSounds[stepIndex];
            stepAudioSource.Play();
        }
    }
}
