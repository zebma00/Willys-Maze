using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimonGame : MonoBehaviour {

    [SerializeField]
    Simon simonPlayer;

    [SerializeField]
    Player player;

    public bool isOurTurn = false;

    public Button upArrow;
    public Button downArrow;
    public Button leftArrow;
    public Button rightArrow;

    [SerializeField]
    AudioClip winningClip;
    
    [SerializeField]
    AudioClip losingClip;

    [SerializeField]
    Text gameStatus;

    [SerializeField] 
    Text currentRoundLabel;
    // Text currentLevelLabel;

    // int currentLevel = 1;
    int currentRound = 1;

    // If this is 0 then it's simons turn, if it's 1 then it's the players turn
    int turn = 0;

    public int numberOfPresses = 4;

    // Use this for initialization
    void Start() {
        List<Button> buttons = new List<Button>() 
        {
            upArrow, downArrow, leftArrow, rightArrow
        };
        foreach (Button b in buttons)
        {
            b.ButtonPressed += HandleButtonPressed;
        }

        simonPlayer.TakeTurn(numberOfPresses);
        turnTaken = true;

        currentRoundLabel.color = new Color(1, 1, 1, 0);

        gameStatus.text = "Listen and repeat...";
    }

    int playerButtonPress = 0;
    private void HandleButtonPressed(Button obj)
    {
        if (turn == 0)
            simonsTurn.Add(obj.name);

        if (turn == 1)
        {
            if (playerButtonPress == numberOfPresses - 1)
            {
                WinRound();
                return;
            }

            if (simonsTurn[playerButtonPress].Equals(obj.name))
            {
                Debug.Log("You hit the right button!");
            }
            else
            {
                LoseRound();
                return;
            }

            playerButtonPress++;
        }
    }

    // void IncreaseLevel()
    void WinRound()
    {
        Debug.Log("Great job! 10 seconds were added to the timer");
        currentRound++;
        // 
        currentRoundLabel.text = "Round " + currentRound.ToString();
        if(numberOfPresses < 7)
        {
            numberOfPresses++;
        }
        Invoke("PlayWinningClip", 0.5f);
        player.isOurTurn = false;
        Invoke("SwitchTurn", 3f);
    }

    // void GameOver()
    void LoseRound()
    {

        // Debug.Log("You hit the wrong button! Game OVER!");
        Debug.Log("You hit the wrong button! 5 seconds were deducted to the timer");
        // currentRound = 1;
        currentRound++;
        // 
        currentRoundLabel.text = "Round " + currentRound.ToString();
        Invoke("PlayLosingClip", 0.5f);
        numberOfPresses = 4;
        player.isOurTurn = false;
        Invoke("SwitchTurn", 4f);

    }

    private void PlayLosingClip()
    {
        GetComponent<AudioSource>().clip = losingClip;
        GetComponent<AudioSource>().Play();
        gameStatus.color = Color.red;
        // gameStatus.text = "Game Over!";
        gameStatus.text = "Try Again!";

        // StartCoroutine(ShowLevelAnimation());
    }

    private void PlayWinningClip()
    {
        GetComponent<AudioSource>().clip = winningClip;
        GetComponent<AudioSource>().Play();

        gameStatus.color = Color.green;
        gameStatus.text = "Well Done!";

        // StartCoroutine(ShowLevelAnimation());
    }

    void SwitchTurn()
    {
        if (gameStatus.color != Color.white)
            gameStatus.color = Color.white;

        turn = 0;
        gameStatus.text = "Listen and repeat...";

        turnTaken = false;
        playerButtonPress = 0;
        simonsTurn.Clear();
    }

    /*
    private IEnumerator ShowLevelAnimation()
    {
        Color c = new Color(1, 1, 1, 0);
        LeanTween.value(currentLevelLabel.gameObject, 0, 1, 0.5f).setOnUpdate((val) =>
        {
            c.a = val;
            currentLevelLabel.color = c;
        });
        yield return new WaitForSeconds(1f);

        LeanTween.value(currentLevelLabel.gameObject, 1, 0, 0.25f).setOnUpdate((val) =>
        {
            c.a = val;
            currentLevelLabel.color = c;
        });
    }
    */

    List<string> simonsTurn = new List<string>();
    bool turnTaken = false;

    // Update is called once per frame
    void Update() {
        // It's Simons turn
        if (turn == 0 && !turnTaken)
        {
            simonPlayer.TakeTurn(numberOfPresses);
            turnTaken = true;
        }
        else if (turn == 0 && turnTaken)
        {
            if (simonsTurn.Count == numberOfPresses)
            {
                Debug.Log("<color=green>SimonGame here! Simon has finished his turn: " + SimonsSelection() + ", now it's your turn to play!</color>");
                player.isOurTurn = true;
                turn = 1;
                Invoke("IsPlayerTurn", 0.5f);
            }
        }

        // It's players turn
        if (turn == 1)
        {

        }
    }

    void IsPlayerTurn()
    {
        gameStatus.text = "Your Turn!";
    }

    private string SimonsSelection()
    {
        string simonsSelectionString = "";
        foreach (string s in simonsTurn)
        {
            simonsSelectionString += s + ", ";
        }

        return simonsSelectionString;
    }
}
