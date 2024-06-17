using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text timerText;
    float elapsedTime;
    [SerializeField] float remainingTime = 300f;
    public Text gameOverText;

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutesElapsed = Mathf.FloorToInt(elapsedTime / 60);
        int secondsElapsed = Mathf.FloorToInt(elapsedTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesElapsed, secondsElapsed);

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0;
            timerText.color = Color.red;
        }
        int minutesRemaining = Mathf.FloorToInt(remainingTime / 60);
        int secondsRemaining = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutesRemaining, secondsRemaining);
    }
}
