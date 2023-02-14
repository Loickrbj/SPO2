using Photon.Pun;
using UnityEngine;
using UnityEngine.Events;

public class CrankPuzzleManager : MonoBehaviourPun
{
    [SerializeField]
    private CrankController crank;

    private LeverController lever;
    private ButtonController button;

    private bool isEverythingActivated;

    private bool isFinished;

    [SerializeField]
    Transform ButtonOrLeverTransform;

    [SerializeField]
    private UnityEvent actionCompleted;

    public void Initialize()
    {
        if (PhotonNetwork.CountOfPlayersInRooms - 1 > 2)
        {
            GameObject go = PhotonNetwork.Instantiate("Button", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            button = go.GetComponent<ButtonController>();
        }
        else
        {
            GameObject go = PhotonNetwork.Instantiate("Lever", ButtonOrLeverTransform.position, ButtonOrLeverTransform.rotation);
            lever = go.GetComponent<LeverController>();
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