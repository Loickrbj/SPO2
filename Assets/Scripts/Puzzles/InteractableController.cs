using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableController : MonoBehaviourPun
{

    [SerializeField]
    LayerMask layerMask;

    [SerializeField]
    float maxDistanceRay = 5f;

    private PhotonView interactObjectView;

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        Ray MiddleScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(MiddleScreenRay, out hit, maxDistanceRay, layerMask))
            {
                switch (hit.transform.tag)
                {
                    case "Button":
                        PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID).RPC("Interact", RpcTarget.All);
                        break;
                    case "Manivelle":
                        interactObjectView = PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID);
                        interactObjectView.RPC("Interact", RpcTarget.All);
                        break;
                    case "Lever":
                        interactObjectView = PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID);
                        interactObjectView.RPC("Interact", RpcTarget.All);
                        break;
                }
            }
        }

        if (interactObjectView != null)
        {
            if (Physics.Raycast(MiddleScreenRay, out hit, maxDistanceRay, layerMask))
            {
                if (PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID) != interactObjectView)
                {
                    interactObjectView.RPC("NotInteract", RpcTarget.All);
                    interactObjectView = null;
                }
            }
            else
            {
                interactObjectView.RPC("NotInteract", RpcTarget.All);
                interactObjectView = null;
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (interactObjectView != null)
            {
                interactObjectView.RPC("NotInteract", RpcTarget.All);
                interactObjectView = null;
            }
        }

    }
}

