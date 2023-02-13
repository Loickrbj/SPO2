using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameMasterUI : MonoBehaviourPun
{
    #region Properties

    #endregion

    #region Attributes
    [SerializeField] private PlayersListUI playerListPanel;
    [SerializeField] private DataListUI dataPanel;
    [SerializeField] private MessageSenderUI messagePanel;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        playerListPanel.Setup(PhotonNetwork.PlayerList);
        /*dataPanel.Setup();*/
    }

    void Update()
    {
        
    }
}
