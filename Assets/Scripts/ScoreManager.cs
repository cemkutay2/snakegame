using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text timerText, snake2DeathCounterText, snake1DeathCounterText;
    float currentTime;
    public float startingTime;
    int snake1DeathCounter, snake2DeathCounter;
    public bool timeRunning;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentTime = startingTime;
        timeRunning = true;
        snake1DeathCounterText.text = "Death Counter: " + snake1DeathCounter.ToString();
        snake2DeathCounterText.text = "Death Counter: " + snake2DeathCounter.ToString();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        timerText.text = $"Timer: {currentTime:N1}";
        if (currentTime == 0) timeRunning = false;
    }
    public void AddSnake1Death()
    {
        snake1DeathCounter++;
        snake1DeathCounterText.text = "Death Counter: " + snake1DeathCounter.ToString();
    }
    public void AddSnake2Death()
    {
        snake2DeathCounter++;
        snake2DeathCounterText.text = "Death Counter: " + snake2DeathCounter.ToString();
    }
}
