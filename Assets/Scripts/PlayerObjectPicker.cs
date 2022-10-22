using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


namespace SPO2.Player
{
    public class PlayerObjectPicker : MonoBehaviourPun
    {

        [SerializeField]
        private Transform handPos;
        [SerializeField]
        private GameObject playerCamera;
        [SerializeField]
        private GameObject gameObjectPointed;
        [SerializeField]
        private GameObject gameObjectGrabbed;
        [SerializeField]
        private float grabDistance;
        [SerializeField]
        private int objectLayer;

        //public float forceY, forceZ;
        public bool objectGrabbed;

        void Start()
        {
            if (!photonView.IsMine)
            {
                this.enabled = false;
                return;
            }
            objectLayer = LayerMask.GetMask("Grabbables");
            objectGrabbed = false;
        }

        void Update()
        {
            if (!photonView.IsMine) return;

            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * grabDistance);
            if(Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hitInfo, grabDistance, objectLayer)){
                gameObjectPointed = hitInfo.collider.gameObject;
            }
            else
            {
                gameObjectPointed = null;
            }

            if (Input.GetKeyDown(KeyCode.E) && gameObjectPointed != null && !objectGrabbed)
            {
                gameObjectGrabbed = gameObjectPointed;
                gameObjectGrabbed.GetComponent<Rigidbody>().isKinematic = true;
                gameObjectGrabbed.transform.position = handPos.position;
                gameObjectGrabbed.transform.parent = transform.root;

                objectGrabbed = true;
            }else if (Input.GetKeyDown(KeyCode.E) && objectGrabbed)
            {
                gameObjectGrabbed.transform.parent = null;
                gameObjectGrabbed.GetComponent<Rigidbody>().isKinematic = false;
                //gameObjectGrabbed.GetComponent<Rigidbody>().AddForce(0, forceY, forceZ);
                gameObjectGrabbed = null;
                objectGrabbed = false;
            }
        }
    }
}

