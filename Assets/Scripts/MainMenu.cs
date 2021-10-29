using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonSound1;

    //NOTE: XR Hand Controllers can only be one or the other: direct interaction or ray interaction
    //For MainMenu, left and right controllers are ray interaction.
    //In DJ Scene, left and right controllers are direct interaction.

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
