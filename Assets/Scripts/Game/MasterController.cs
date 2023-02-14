using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviourPun
{
    public KeyCode nextPhaseKey = KeyCode.Return;
    private PuzzleManager puzzleManager;

    private void Awake()
    {
        if(puzzleManager == null)
        {
            puzzleManager = FindObjectOfType<PuzzleManager>();
        }
    }

    private void Update()
    {
        if(photonView.IsMine && PhotonNetwork.IsMasterClient)
        {
            if (Input.GetKeyDown(nextPhaseKey))
            {
                photonView.RPC("NextEventPhaseRPC", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    private void NextEventPhaseRPC()
    {
        puzzleManager.PlayNextEvent();
    }

}
