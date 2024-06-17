using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ArrowKey : MonoBehaviour
{
    public KeyCode keyToPress;

    public static event Action<string> SendKeyValue = delegate { };

    public void ButtonClicked()
    {
        SendKeyValue(name);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) 
        {
            SendKeyValue(name);
        }
    } 
}
