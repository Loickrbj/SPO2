using UnityEngine;
using UnityEngine.Events;

public class PressurePlateManager : MonoBehaviour
{
    [SerializeField] private int numberOfPlayers = 1;
    [SerializeField] private PressurePlate pressurePlate1;
    [SerializeField] private PressurePlate pressurePlate2;
    [SerializeField] private PressurePlate pressurePlate3;

    public UnityEvent OnWinEvent;

    private bool isWon;

    private void Start()
    {
        InitializePlates();
    }

    private void Update()
    {
        if (isWon)
        {
            return;
        }

        if (CheckWin())
        {
            isWon = true;
            OnWinEvent.Invoke();
            Debug.Log("Pressure plates OK!");
        }
    }

    private void InitializePlates()
    {
        pressurePlate1.gameObject.SetActive(false);
        pressurePlate2.gameObject.SetActive(false);
        pressurePlate3.gameObject.SetActive(false);
        if (numberOfPlayers >= 1)
        {
            pressurePlate1.gameObject.SetActive(true);
            pressurePlate1.NumberOfPlayersRequired = 1;
        }
        if (numberOfPlayers >= 2)
        {
            pressurePlate2.gameObject.SetActive(true);
            pressurePlate2.NumberOfPlayersRequired = 1;
        }
        if (numberOfPlayers >= 3)
        {
            pressurePlate3.gameObject.SetActive(true);
            pressurePlate3.NumberOfPlayersRequired = 1;
        }
        if (numberOfPlayers >= 4)
        {
            pressurePlate3.gameObject.SetActive(true);
            pressurePlate2.NumberOfPlayersRequired = 2;
        }
        if (numberOfPlayers >= 5)
        {
            pressurePlate3.gameObject.SetActive(true);
            pressurePlate3.NumberOfPlayersRequired = 2;
        }
    }

    private bool CheckWin()
    {
        if (numberOfPlayers >= 1)
        {
            if (!pressurePlate1.IsActivated)
            {
                return false;
            }
        }
        if (numberOfPlayers >= 2)
        {
            if (!pressurePlate1.IsActivated)
            {
                return false;
            }
            if (!pressurePlate2.IsActivated)
            {
                return false;
            }
        }
        if (numberOfPlayers >= 3)
        {
            if (!pressurePlate3.IsActivated)
            {
                return false;
            }
        }
        return true;
    }
}
