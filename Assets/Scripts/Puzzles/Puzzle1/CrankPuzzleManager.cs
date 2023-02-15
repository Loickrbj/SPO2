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
        if (PhotonNetwork.PlayerList.Length - 1 > 2)
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
        if (lever.gameObject.activeInHierarchy && lever.IsActivated && crank.IsRotating)
        {
            isEverythingActivated = true;
        }

        if (button.gameObject.activeInHierarchy && button.IsActivated && crank.IsRotating)
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