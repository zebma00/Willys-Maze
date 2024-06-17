using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool isOurTurn = false;

    public ButtonFX upArrow;
    public ButtonFX downArrow;
    public ButtonFX leftArrow;
    public ButtonFX rightArrow;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(!isOurTurn)
            {return;}
        if(Input.GetKeyDown(KeyCode.UpArrow)) {}
        {
            upArrow.Activate();
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)) {}
        {
            downArrow.Activate();
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)) {}
        {
            leftArrow.Activate();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)) {}
        {
            rightArrow.Activate();
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)) {}
        {
            upArrow.Deactivate();
        }
        if(Input.GetKeyUp(KeyCode.DownArrow)) {}
        {
            downArrow.Deactivate();
        }
        if(Input.GetKeyUp(KeyCode.LeftArrow)) {}
        {
            leftArrow.Deactivate();
        }
        if(Input.GetKeyUp(KeyCode.RightArrow)) {}
        {
            rightArrow.Deactivate();
        }
	}
}
