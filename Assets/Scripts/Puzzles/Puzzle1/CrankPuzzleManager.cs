using Photon.Pun;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class CrankPuzzleManager : MonoBehaviourPun
{
    [SerializeField]
    private CrankController crank;
    private LeverController lever;
    private ButtonController button;

    [SerializeField]
    private int countOfPlayerToContinousTurn;

    private bool completed = false;
    private bool finished = false;

    [SerializeField]
    Transform ButtonOrLeverTransform;

    [SerializeField]
    private UnityEvent actionCompleted;

    private void Start()
    {
        if (PhotonNetwork.CountOfPlayersInRooms >= countOfPlayerToContinousTurn)
        {
            Destroy(button);
            GameObject go = PhotonNetwork.Instantiate("Lever", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            lever = go.GetComponent<LeverController>();
        }
        else
        {
            Destroy(lever);
            GameObject go = PhotonNetwork.Instantiate("Button", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            button = go.GetComponent<ButtonController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (lever != null)
        {
            if (lever.IsActivated && crank.isMoving)
            {
                completed = true;
            }
            else
            {
                completed = false;
                finished = false;
            }
        }

        if( button != null)
        {
            if (button.IsActivated && crank.isMoving)
            {
                completed = true;
            }
            else
            {
                completed = false;
                finished = false;
            }
        }

        if (!finished && completed)
        {
            actionCompleted.Invoke();
            finished = true;
            Debug.Log("L4ENGIME EST RESOLU SUSSY BAKA");
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
