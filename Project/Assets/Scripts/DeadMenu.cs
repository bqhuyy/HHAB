using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    public SceneFader fader;
    const string mainMenuScene = "MainMenuScene";
    // Start is called before the first frame update
    private void Start()
    {
        fader = (SceneFader)FindObjectOfType(typeof(SceneFader));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        Destroy(GameObject.Find("LobbyManager"));
        fader.FadeTo(mainMenuScene);
    }
}
