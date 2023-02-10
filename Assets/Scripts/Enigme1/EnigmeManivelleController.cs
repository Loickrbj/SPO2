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
    UnityEvent actionNotCompleted;

    [SerializeField]
    bool completed = false;

    bool finished = false;

    public bool switchActivated = false;

    public bool ManivelleActivated = false;

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
                finished = false;
            }
            switchActivated = lever.IsActivated;
        }

        if( button != null)
        {
            if (button.IsActivated && manivelle.isMoving)
            {
                completed = true;
            }
            else
            {
                completed = false;
                finished = false;
            }
            switchActivated = button.IsActivated;
        }


        if (!finished && completed)
        {
            actionCompleted.Invoke();
            finished = true;
            desactivated = false;
        }

        ManivelleActivated = manivelle.isMoving;
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
