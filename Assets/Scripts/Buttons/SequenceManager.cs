using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceManager : MonoBehaviour
{
    private string correctSequence, currentSequence;

    public AudioSource mySounds;
    public AudioClip upKey;
    public AudioClip downKey;
    public AudioClip leftKey;
    public AudioClip rightKey;

    // Start is called before the first frame update
    void Start()
    {
        ArrowKey.SendKeyValue += AddValueAndCheckSequence;
        RandomizeCorrectSequence();
        // SpellCorrectSequence();
        currentSequence = "";
    }

    private void AddValueAndCheckSequence(string arrowKey)
    {
        switch (arrowKey)
        {
            case "UP":
                currentSequence += 1;
                break;
            case "DOWN":
                currentSequence += 2;
                break;
            case "LEFT":
                currentSequence += 3;
                break;
            case "RIGHT":
                currentSequence += 4;
                break;
        }

        if (currentSequence != correctSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
        }
        else if (currentSequence == correctSequence)
        {
            // Timer.remainingTime += 10;
            // PlayerMovement.moveSpeed += 2;
            RandomizeCorrectSequence();
            // SpellCorrectSequence();
            currentSequence = "";
        }
            
    }

    private void OnDestroy()
    {
        ArrowKey.SendKeyValue -= AddValueAndCheckSequence;
    }

    private void RandomizeCorrectSequence()
    {
        string str = "1234"; 
        int size = 7; 

        // Initializing the empty string 
        string ran = ""; 
  
        for (int i = 0; i < size; i++) 
        { 
            // Selecting a index randomly between 0 and 3
            int x = Random.Range(0, 4);
    
            // Appending the character at the  
            // index to the random string. 
            ran += str[x]; 
        } 
        string ranStr = ran.ToString();
        correctSequence = ranStr;
        
        print("The Correct Sequence is " + correctSequence);
    }

    /*
    private IEnumerator SpellCorrectSequence()
    {
        for(int i = 0; i < correctSequence.Length; i++)
        {
            while(mySounds.isPlaying)
            {
                yield return new WaitForSeconds(0.05f);
            }

            switch (correctSequence[i])
            {      
                case '1':
                    mySounds.PlayOneShot(upKey);
                    break;
                case '2':
                    mySounds.PlayOneShot(downKey);
                    break;
                case '3':
                    mySounds.PlayOneShot(leftKey);
                    break;
                case '4':
                    mySounds.PlayOneShot(rightKey);
                    break;
            }
        }
    }
    */
}
