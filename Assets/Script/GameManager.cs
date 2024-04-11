using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float startTime;
    private bool isGameRunning = false;

    void Start()
    {
        StartGame();
    }

    void StartGame() //start timer
    {
        startTime = Time.time;
        isGameRunning = true;
    }

    void Update() //as long as game run, timer keep update
    {
        if (isGameRunning)
        {
            UpdateTimer();
        }
    }

    void UpdateTimer() //update timer fuction
    {
        float elapsedTime = Time.time - startTime;
        string minutes = Mathf.Floor(elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");
        timerText.text = "Time: " + minutes + ":" + seconds;
    }
}

