using UnityEngine;
using UnityEngine.Events;

public class PressurePlateManager : MonoBehaviour
{
    [SerializeField] private int numberOfPlayers = 1;
    [SerializeField] private PressurePlate pressurePlate1;
    [SerializeField] private PressurePlate pressurePlate2;
    [SerializeField] private PressurePlate pressurePlate3;

    public UnityEvent OnWinEvent;

    private void Start()
    {
        if (numberOfPlayers >= 1)
        {
            pressurePlate1.gameObject.SetActive(true);
        }
        if (numberOfPlayers >= 2)
        {
            pressurePlate2.gameObject.SetActive(true);
        }
        if (numberOfPlayers >= 3)
        {
            pressurePlate3.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        if (CheckWin())
        {
            OnWinEvent.Invoke();
            Debug.Log("Pressure plates OK!");
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
