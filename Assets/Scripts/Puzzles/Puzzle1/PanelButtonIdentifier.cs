using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelButtonIdentifier : MonoBehaviour
{
    public int value;
    public LeverController leverController;

    private void Start()
    {
        if (leverController == null) leverController = GetComponent<LeverController>();
    }
}
