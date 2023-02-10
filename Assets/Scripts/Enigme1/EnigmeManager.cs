using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnigmeManager : MonoBehaviour
{
    public UnityEvent[] events;

    public void PlayEventPhase(int i)
    {
        events[i].Invoke();
    }
}
