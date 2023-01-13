using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPO2.Player
{
    public class CameraController : MonoBehaviourPun
    {
        [SerializeField] private float mouseSensitivity = 100;
        [SerializeField] private Transform playerTransform;
        private float xRotation = 0f;

        private void Start()
        {
            if (!photonView.IsMine)
            {
                GetComponent<Camera>().enabled = false;
                //gameObject.SetActive(false);
                return;
            }
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void LateUpdate()
        {
            if (!photonView.IsMine) return;

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90, 90);

            transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
            playerTransform.Rotate(Vector3.up * mouseX);
        }
    }
}

