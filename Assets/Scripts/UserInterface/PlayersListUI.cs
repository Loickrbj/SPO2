using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PlayersListUI : MonoBehaviourPun
{
    [SerializeField] private PlayerDataUI playerDataPrefab;
    [SerializeField] private GameObject viewport;
    [SerializeField] private TextMeshProUGUI playersCount;

    private List<Photon.Realtime.Player> playerDataList = new List<Photon.Realtime.Player>();

    public void Setup(Photon.Realtime.Player[] players)
    {
        foreach (Photon.Realtime.Player player in players)
        {
            PlayerDataUI playerDataUI = Instantiate(playerDataPrefab, viewport.transform); 
            playerDataUI.Setup(player);
            playerDataList.Add(player);
            
        }
        playersCount.SetText(players.Length.ToString() + " players");
    }
}
