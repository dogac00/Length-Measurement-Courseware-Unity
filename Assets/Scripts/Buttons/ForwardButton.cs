using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ForwardButton : GameButton
{
    protected override void OnClick()
    {
        Globals.PanelMode = false;

        LoadNextScene();
    }

    protected virtual void LoadNextScene()
    {
        string sceneName = GetNextSceneName();

        SceneManager.LoadScene(sceneName);
    }

    private string GetNextSceneName()
    {
        string thisScene = SceneManager.GetActiveScene().name;

        int thisSceneNumber = thisScene.GetLastTwoDigit();

        return string.Concat("Scene", thisSceneNumber + 1);
    }
}
