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

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            return;
        }

        Ray MiddleScreenRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(MiddleScreenRay, out hit, maxDistanceRay, layerMask))
        {
            switch (hit.transform.tag)
            {
                case "Lever":
                    print("LEVER");
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID).RPC("Interact",RpcTarget.All);
                    }
                    break;
                case "Manivelle":
                    if (Input.GetKey(KeyCode.E))
                    {
                        PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID).RPC("Interact",RpcTarget.All);
                    }
                    else
                    {
                        PhotonView.Find(hit.transform.GetComponent<PhotonView>().ViewID).RPC("NotInteract", RpcTarget.All);
                    }
                    break;
                case "Button":
                    //hit.transform.GetComponent<ButtonController>().Interact();
                    break;

            }
        }
    }
}

