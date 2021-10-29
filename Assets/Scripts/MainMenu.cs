using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //NOTE: XR Hand Controllers can only be one or the other: direct interaction or ray interaction
    //For MainMenu, left and right controllers are ray interaction.
    //In DJ Scene, left and right controllers are direct interaction.

    public AudioSource buttonSound1;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonHoverSound()
    {
        buttonSound1.Play();
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    
}
