using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;

    private string multiplayerScene = "MultiplayerScene";
    private string inGameScene = "InGameScene";

    public void Play()
    {
        fader.FadeTo(inGameScene);
    }

    public void Multplayer()
    {
        fader.FadeTo(multiplayerScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
