using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class CrankPuzzleManager : MonoBehaviourPun
{
    [SerializeField]
    private CrankController crank;

    [SerializeField]
    private LeverController lever;

    [SerializeField]
    private ButtonController button;

    private bool isEverythingActivated;

    private bool isFinished;

    [SerializeField]
    private UnityEvent actionCompleted;

    public void Initialize()
    {
        if (PhotonNetwork.CountOfPlayersInRooms - 1 > 2)
        {
            button.gameObject.SetActive(false);
        }
        else
        {
            lever.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (lever != null && lever.IsActivated && crank.IsRotating)
        {
            isEverythingActivated = true;
        }

        if (button != null && button.IsActivated && crank.IsRotating)
        {
            isEverythingActivated = true;
        }

        if (isEverythingActivated && !isFinished)
        {
            isFinished = true;
            actionCompleted.Invoke();
        }
    }
}