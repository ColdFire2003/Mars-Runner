using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private string mainScene;
    [SerializeField] private string MainMenu;

    //Sends the player to the dino dating scene
    public void PlayButton()
    {
        StartCoroutine(openNextScene());
    }

    //Closes the game
    public void QuitButton()
    {
        StartCoroutine(quit());
    }

    //when player is in a different scene
    //this buttons will send the player back to the mainmenu.
    public void MainMenuButton()
    {
        StartCoroutine(openMainMenu());
    }

    public void PressedButton()
    {
        StartCoroutine(PressButton());
    }
    #region Coroutines
    //This runs when you press play, it waits for a very short time so a sound on the button can play
    IEnumerator openNextScene()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(mainScene);
    }

    //this will send the player back to the MainMenu
    IEnumerator openMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(MainMenu);
    }

    //This runs when you press play, it waits for a very short time so a sound on the button can play and quit the game
    IEnumerator quit()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
        Application.Quit();
    }

    IEnumerator PressButton()
    {
        FindObjectOfType<AudioManager>().Play("Button");
        yield return new WaitForSeconds(0.25f);
    }
    #endregion
}
