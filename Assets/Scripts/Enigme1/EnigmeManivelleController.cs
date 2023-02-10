using Photon.Pun;
using System.ComponentModel;
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

    public bool switchActivated = false;

    public bool ManivelleActivated = false;

    [SerializeField]
    Transform Position;

    [SerializeField]
    GameObject leverPrefab;
    [SerializeField]
    GameObject buttonPrefab;

    private void Start()
    {
        if (PhotonNetwork.CountOfPlayersInRooms >= countOfPlayerToContinousTurn)
        {
            Destroy(button);
            GameObject go = Instantiate(leverPrefab);
            go.transform.position = Position.position;
        }
        else
        {
            Destroy(lever);
            GameObject go = Instantiate(buttonPrefab);
            go.transform.position = Position.position;
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
            Debug.Log("L4ENGIME EST RESOLU SUSSY BAKA");
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
