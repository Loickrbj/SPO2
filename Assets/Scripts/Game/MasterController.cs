using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviourPun
{
    public KeyCode nextPhaseKey = KeyCode.Return;
    public KeyCode MainVoicelineKey = KeyCode.I;
    public KeyCode FlavorVoicelineKey = KeyCode.O;
    public KeyCode ClueVoicelineKey = KeyCode.P;
    private PuzzleManager puzzleManager;

    private bool skipVoiceline = false;

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
            if (Input.GetKeyDown(KeyCode.U))
            {
                skipVoiceline = true;
            }
            if (Input.GetKeyUp(KeyCode.U))
            {
                skipVoiceline = false;
            }
            if (Input.GetKeyDown(nextPhaseKey))
            {
                photonView.RPC("NextEventPhaseRPC", RpcTarget.All);
            }
            if (Input.GetKeyDown(MainVoicelineKey))
            {
                photonView.RPC("CallMainVoicelineRPC", RpcTarget.All, skipVoiceline);
            }
            if (Input.GetKeyDown(FlavorVoicelineKey))
            {
                photonView.RPC("CallFlavorVoicelineRPC", RpcTarget.All, skipVoiceline);
            }
            if (Input.GetKeyDown(ClueVoicelineKey))
            {
                photonView.RPC("CallClueVoicelineRPC", RpcTarget.All, skipVoiceline);
            }
        }
    }

    [PunRPC]
    private void NextEventPhaseRPC()
    {
        puzzleManager.PlayNextEvent();
    }

    [PunRPC]
    private void CallMainVoicelineRPC(bool skip)
    {
        VoiceManager.CallMainVoiceline(skip);
    }

    [PunRPC]
    private void CallFlavorVoicelineRPC(bool skip)
    {
        VoiceManager.CallFlavorVoiceline(skip);
    }

    [PunRPC]
    private void CallClueVoicelineRPC(bool skip)
    {
        VoiceManager.CallClueVoiceline(skip);
    }
}
