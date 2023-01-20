using Photon.Pun;
using UnityEngine;

public class EnigmeManivelleController : MonoBehaviourPun
{
    [SerializeField]
    private ManivelleController manivelle;

    [SerializeField]
    private LeverController lever;

    [SerializeField]
    private ButtonController button;

    [SerializeField]
    int countOfPlayerToContinousTurn;

    [SerializeField]
    bool completed = false;

    private void Start()
    {
        if (PhotonNetwork.CountOfPlayersInRooms >= countOfPlayerToContinousTurn)
        {
            Destroy(button);
        }
        else
        {
            Destroy(lever);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lever != null)
        {
            if (lever.IsActivated && manivelle.isMoving)
            {
                completed = true;
            }
            else
            {
                completed = false;
            }
        }

        if( button != null)
        {
            if (button.IsActivated && manivelle.isMoving && !completed)
            {
                completed = true;
            }
        }
    }

    public bool isCompleted
    {
        get
        {
            return completed;
        }
    }
}
