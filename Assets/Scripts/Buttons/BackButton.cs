using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : GameButton
{
    private string sceneName;

    protected override void Awake()
    {
        base.Awake();

        sceneName = GetPreviousSceneName();
    }

    protected override void OnClick()
    {
        SceneManager.LoadScene(sceneName);
    }

    private string GetPreviousSceneName()
    {
        string thisScene = SceneManager.GetActiveScene().name;

        int thisSceneNumber = thisScene.GetLastTwoDigit();

        return string.Concat("Scene", thisSceneNumber - 1);
    }
}
