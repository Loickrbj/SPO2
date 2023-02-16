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
        if (PhotonNetwork.PlayerList.Length - 1 == 2)
        {
            button.gameObject.SetActive(true);
        }
        if (PhotonNetwork.PlayerList.Length - 1 == 3)
        {
            lever.gameObject.SetActive(true);
        }
        if (PhotonNetwork.PlayerList.Length - 1 >= 4)
        {
            button.gameObject.SetActive(true);
            lever.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        isEverythingActivated = true;

        if (button.gameObject.activeInHierarchy)
        {
            if (!button.IsActivated)
            {
                isEverythingActivated = false;
            }
        }

        if (lever.gameObject.activeInHierarchy)
        {
            if (!lever.IsActivated)
            {
                isEverythingActivated = false;
            }
        }

        if (!crank.IsRotating)
        {
            isEverythingActivated = false;
        }

        if (isEverythingActivated && !isFinished)
        {
            isFinished = true;
            actionCompleted.Invoke();
        }
    }
}