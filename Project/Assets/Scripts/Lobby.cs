using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    public SceneFader fader;

    const string mainMenuScene = "MainMenuScene";

    public void BackToMenu()
    {
        fader.FadeTo(mainMenuScene);
        Destroy(gameObject);
    }
}
