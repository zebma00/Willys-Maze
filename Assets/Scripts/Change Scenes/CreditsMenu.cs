using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public void GoBackToStartMenu()
    {
        SceneManager.LoadScene("Start Menu");
    }
}
