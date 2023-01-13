using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    public static GameObject localPlayer;
    public TextMeshPro pseudo;

    private void Awake()
    {
        if (photonView.IsMine)
        {
            localPlayer = this.gameObject;
            pseudo.gameObject.SetActive(false);
        }
        // #Critical
        // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        pseudo.text = photonView.Controller.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
