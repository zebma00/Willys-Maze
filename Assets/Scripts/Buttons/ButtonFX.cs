using System;
using System.Collections;
using System.Collections. Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class ButtonFX : MonoBehaviour
{
    private Image image;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;
    public int mouseButtonToPress;

    public AudioSource mySounds;
    public AudioClip clickSound;

    public event Action<ButtonFX> ButtonPressed;

    public bool isOurTurn = false;

    void Start()
    {
        image = GetComponent<Image>();
    }

    /*
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) 
        {
            image.sprite = pressedImage;
            mySounds.PlayOneShot(clickSound);
            if(buttonPressed != null)
                buttonPressed(this);
        }

        if(Input.GetKeyUp(keyToPress))
        {
            image.sprite = defaultImage;
        }
    }
    */

    public void Activate()
    {
        image.sprite = pressedImage;
        mySounds.PlayOneShot(clickSound);
        if(ButtonPressed != null)
            ButtonPressed(this);
    }

    public void Deactivate()
    {
        image.sprite = defaultImage;
    }
}