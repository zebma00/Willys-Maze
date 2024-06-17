using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    public Text gameOverText;
    public Text WinText;
    float elapsedTime;

    [SerializeField] Text timerText;
    [SerializeField] Text yourTimeText;
    [SerializeField] Text highScoreText;

    float defaultHighScore = 120; 

    void Start()
    {
        UpdateHighScoreText();
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
        int secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesElapsed, secondsElapsed);
        yourTimeText.text = $"Your Time: {timerText.text}";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Win")
        {
            WinText.gameObject.SetActive(true);
            Time.timeScale = 0;
            CheckHighScore();
            UpdateHighScoreText();
        }

        if(collision.tag == "Lose")
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void CheckHighScore()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if(elapsedTime < PlayerPrefs.GetFloat("HighScore1", 120))
            {
                PlayerPrefs.SetFloat("HighScore1", elapsedTime);
            }
        }

        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            if(elapsedTime < PlayerPrefs.GetFloat("HighScore2", 120))
            {
                PlayerPrefs.SetFloat("HighScore2", elapsedTime);
            }
        }

        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            if(elapsedTime < PlayerPrefs.GetFloat("HighScore3", 120))
            {
                PlayerPrefs.SetFloat("HighScore3", elapsedTime);
            }
        }
    }

    

    public void UpdateHighScoreText()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            int minutes1 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore1", defaultHighScore) / 60);
            int seconds1 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore1", defaultHighScore)  % 60);
            string highScoreFormat1 = string.Format("{0:00}:{1:00}", minutes1, seconds1);
            highScoreText.text = $" Fastest Time - {highScoreFormat1}";
        }
        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            int minutes2 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore", defaultHighScore) / 60);
            int seconds2 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore", defaultHighScore)  % 60);
            string highScoreFormat2 = string.Format("{0:00}:{1:00}", minutes2, seconds2);
            highScoreText.text = $" Fastest Time - {highScoreFormat2}";
        }
        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            int minutes3 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore3", defaultHighScore) / 60);
            int seconds3 = Mathf.FloorToInt(PlayerPrefs.GetFloat("HighScore3", defaultHighScore)  % 60);
            string highScoreFormat3 = string.Format("{0:00}:{1:00}", minutes3, seconds3);
            highScoreText.text = $" Fastest Time - {highScoreFormat3}";
        }
    }
}
