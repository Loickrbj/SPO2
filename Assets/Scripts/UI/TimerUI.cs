using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private Button startButton;
    [SerializeField] private Button pauseButton;

    private float timeRemaining = 600;
    private bool timerIsRunning = false;

    private void Start()
    {
        Debug.Log("Hello");
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        float mili = Mathf.FloorToInt((int)(timeRemaining * 100) % 100);
        timeText.SetText(string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, mili));

        startButton.onClick.AddListener(StartTimer);
        pauseButton.onClick.AddListener(PauseTimer);

    }

    private void OnDestroy()
    {
        startButton.onClick.RemoveListener(StartTimer);
        pauseButton.onClick.RemoveListener(PauseTimer);
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void PauseTimer()
    {
        timerIsRunning = false;
    }

    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        float mili = Mathf.FloorToInt((int)(timeRemaining * 100) % 100);
        timeText.SetText(string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, mili));
    }


}
