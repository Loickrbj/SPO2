using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

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
    UnityEvent actionCompleted;

    [SerializeField]
    bool completed = false;

    bool finished = false;

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


        if (!finished && completed)
        {
            actionCompleted.Invoke();
            finished = true;
        }
    }

    public bool isCompleted
    {
        get
        {
            return completed;
        }
    }

    public void baka()
    {
        Debug.Log("BAKA");
    }


}
