using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerV2 : MonoBehaviour
{
    public float timeRemaining = 10.0f;
    public bool timerIsRunning = false;

    private Text timeText;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.Find("time").GetComponent<Text>();

        // Starts the timer automatically
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(timerIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                // Debug.Log("Times Up!");
                timeText.text = string.Format("Times Up!");
                timeRemaining = 0;
                timerIsRunning = false;
                GameOver();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void GameOver()
    {
        Time.timeScale = 0.0f;
        MoveV2 move_script = GetComponent<MoveV2>();
        move_script.enabled = false;
        Application.Quit();
    }
}