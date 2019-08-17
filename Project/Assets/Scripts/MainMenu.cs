using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader fader;
    public GameObject audioSource;

    const string multiplayerScene = "MultiplayerScene";
    const string inGameScene = "InGameScene";

    private void Start()
    {
        DontDestroyOnLoad(audioSource);
    }

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
