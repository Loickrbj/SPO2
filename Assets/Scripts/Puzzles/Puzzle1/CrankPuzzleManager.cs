using Photon.Pun;
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

    private bool isEverythingActivated;

    private bool isFinished;

    [SerializeField]
    Transform ButtonOrLeverTransform;

    [SerializeField]
    private UnityEvent actionCompleted;

    public void Initialize()
    {
        if (PhotonNetwork.CountOfPlayersInRooms >= countOfPlayerToContinousTurn)
        {
            GameObject go = PhotonNetwork.Instantiate("Lever", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            lever = go.GetComponent<LeverController>();
        }
        else
        {
            GameObject go = PhotonNetwork.Instantiate("Button", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            button = go.GetComponent<ButtonController>();
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
            Debug.Log("L'ENGIME EST RESOLU SUSSY BAKA");
        }
    }
}