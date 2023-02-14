using UnityEngine;
using UnityEngine.Events;

public class PuzzleManager : MonoBehaviour
{
    public UnityEvent[] events;
    private int lastEventIndex = 0;

    public void PlayEventPhase(int i)
    {
        Debug.Assert(events.Length > i, "Event index '" + i + "' doesn't exist");
        if (events.Length > i)
        {
            events[i].Invoke();
            lastEventIndex = i;
        }
    }

    public void PlayNextEvent()
    {
        Debug.Assert(events.Length > lastEventIndex, "Event index '" + lastEventIndex + "' doesn't exist");
        if (events.Length > lastEventIndex)
        {
            events[lastEventIndex].Invoke();
            lastEventIndex++;
        }
    }
}
