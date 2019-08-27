using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadMenu : MonoBehaviour
{
    public SceneFader fader;
    const string multiplayerScene = "MultiplayerScene";
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
        fader.FadeTo(multiplayerScene);
    }
}
