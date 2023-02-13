using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerDataUI : MonoBehaviourPun
{
    [SerializeField] private TextMeshProUGUI nickname;
    
    public void Setup(Photon.Realtime.Player player)
    {
        nickname.SetText(player.NickName);
    }
    
}
