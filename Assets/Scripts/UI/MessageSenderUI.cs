using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageSenderUI : MonoBehaviour
{
    [SerializeField] private Button messageSenderButton;

    void Start()
    {
        messageSenderButton.onClick.AddListener(SendMessage);
    }

    private void OnDestroy()
    {
        messageSenderButton.onClick.RemoveListener(SendMessage);
    }

    private void SendMessage()
    {
        
    }
}
