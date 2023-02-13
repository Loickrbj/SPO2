using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public UnityEvent[] events;

    public void PlayEventPhase(int i)
    {
        events[i].Invoke();
    }
}
