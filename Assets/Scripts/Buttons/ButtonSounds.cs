using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    public AudioSource mySounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;


    public void HoverSound() {
        mySounds.PlayOneShot(hoverSound);
    }

    public void ClickSound() {
        mySounds.PlayOneShot(clickSound);
    }
}
