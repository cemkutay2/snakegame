using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text snake1DeathCounterText;
    public Text highScoreText;
    public Text snake2DeathCounterText;
    int highScore;
    int snake1DeathCounter;
    int snake2DeathCounter;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        snake1DeathCounterText.text = "Death Counter: " + snake1DeathCounter.ToString();
        highScoreText.text = "Highscore: " + highScore.ToString();
        snake2DeathCounterText.text = "Death Counter: " + snake2DeathCounter.ToString();
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
